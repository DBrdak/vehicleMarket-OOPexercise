using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.DisplayExtensions
{
    public static class ListDisplay
    {
        public static string ListToString<T>(this List<T> list)
        {
            var result = new StringBuilder();

            foreach (var item in list)
            {
                result.AppendLine(item.ToString());
            }

            return result.ToString();
        }
    }
}
