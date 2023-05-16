using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Core;

namespace Application.Core
{
    public static class Mapper
    {
        public static T MapTo<T>(this string[] rawValues) where T : Vehicle
        {
            try
            {
                var props = AdjustProperties(typeof(T));

                var propTypes = new Type[props.Length];
                var values = new object[rawValues.Length];

                for (int i = 0; i < propTypes.Length; i++)
                    propTypes[i] = props[i].PropertyType;

                for (int i = 0; i < rawValues.Length; i++)
                {
                    if (propTypes[i].IsEnum)
                        values[i] = Enum.Parse(propTypes[i], rawValues[i]);
                    else
                        values[i] = Convert.ChangeType(rawValues[i], propTypes[i]);
                }

                return (T)Activator.CreateInstance(typeof(T), values);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Can't map values to object of type {typeof(T).Name}, reason: {e.Message}");
                throw;
            }

            
        }

        private static PropertyInfo[] AdjustProperties(Type type)
        {
            var propList = type.GetProperties().ToList();
            propList.Remove(propList.Single(p => p.Name == "Id"));

            var props = propList.Skip(propList.FindIndex(p => p.Name == "Make")).ToArray();
            var temp = propList.Take(propList.FindIndex(p => p.Name == "Make")).ToArray();
            props = props.Concat(temp).ToArray();

            for (int i = 10; i < temp.Length; i++)
                props[i] = temp[i];

            return props;
        }
    }
}
