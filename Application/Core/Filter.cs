using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;

namespace Application.Core
{
    public static class Filter
    {
        public static List<T> SetFilter<T>(this List<T> list, string propFilter, Range valuesRange) where T : Vehicle
        {
            var (from, to) = (valuesRange.Start.Value, valuesRange.End.Value);

            return list.Where(p =>
            {
                var prop = p.GetType().GetProperty(propFilter) ?? throw new ArgumentNullException("Wrong filer selected");
                var propValue = (int)prop.GetValue(p);
                return propValue >= from && propValue <= to;
            }).ToList();
        }

        public static List<T> SetFilter<T>(this List<T> list, string propFilter, string searchPhrase) where T : Vehicle
        {
            return list.Where(p =>
            {
                var prop = p.GetType().GetProperty(propFilter) ?? throw new ArgumentNullException("Wrong filer selected");
                return (string)prop.GetValue(p) == searchPhrase;
            }).ToList();
        }
    }
}