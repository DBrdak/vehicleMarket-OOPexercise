using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core;

namespace Application.Core
{
    public static class Pagination
    {
        public static IEnumerable<T> AtPage<T>(this IEnumerable<T> list, int pageNumber, int pageSize = 10) where T : Vehicle
            => list.Skip((pageNumber - 1) * pageSize).Take(pageSize);

    }
}
