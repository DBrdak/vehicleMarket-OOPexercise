using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core;

namespace Domain.Common
{
    public abstract class Sorter
    {
        public class MileageSort : IComparer<Vehicle>
        {
            public int Compare(Vehicle x, Vehicle y)
            {
                if(x is null)
                    return -1;
                if(y is null)
                    return 1;

                return x.Mileage - y.Mileage;
            }
        }
        public class AgeSort : IComparer<Vehicle>
        {
            public int Compare(Vehicle x, Vehicle y)
            {
                if (x is null)
                    return -1;
                if (y is null)
                    return 1;

                return x.ProductionYear - y.ProductionYear;
            }
        }
        public class PriceSort : IComparer<Vehicle>
        {
            public int Compare(Vehicle x, Vehicle y)
            {
                if (x is null)
                    return -1;
                if (y is null)
                    return 1;

                return x.Price - y.Price;
            }
        }
    }
}
