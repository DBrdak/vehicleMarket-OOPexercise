using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Domain.Common.Attributes;

namespace Domain.Common.Enums
{
    public static class EnumExtensions
    {
        public static string FromTranslatedString<T>(this string value) where T : Enum
        {
            var fields = typeof(T).GetFields();

            foreach (var field in fields)
            {
                var attribute = field.GetCustomAttribute<TranslatedNameAttribute>();

                if (attribute == null && field.Name == value || attribute != null && attribute.Translate() == value)
                    return field.Name;
            }

            return null;
        }

        public static string ToTranslatedString<T>(this T value) where T : Enum
        {
            var enumType = typeof(T);
            var field = enumType.GetField(value.ToString());

            if (field == null)
                return string.Empty;

            var attribute = field.GetCustomAttribute<TranslatedNameAttribute>();

            if (attribute == null)
                return value.ToString();

            return attribute.Translate();
        }
    }
}