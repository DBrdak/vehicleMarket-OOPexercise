using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Domain.Common.Enums;
using Microsoft.VisualBasic.CompilerServices;

namespace Domain.Core
{
    public class Truck : Vehicle
    {
        public int Torque { get; }
        public int GVW { get; }
        [RegularExpression("^\\d+x\\d+x\\d+$")]
        public string LoadCapacity { get; }
        public int Axles { get; }
        public TruckType Type { get; }

        public Truck(string make, string model, int productionYear, int mileage, 
            int power, int cubicCapacity, Fuel fuelType, string city, string phoneNumber, 
            int price, int gvw, string loadCapacity, int axles, TruckType type, int torque) 
            : base(make, model, productionYear, mileage, power, cubicCapacity, fuelType, city, phoneNumber, price)
        {
            GVW = gvw;
            LoadCapacity = loadCapacity;
            Axles = axles;
            Type = type;
            Torque = torque;
        }
        
        public static explicit operator Truck(string[] values)
        {
            var parseResult = Enum.TryParse(typeof(Fuel), values[6], true, out var fuel);
            parseResult = Enum.TryParse(typeof(TruckType), values[13], true, out var type);

            if(parseResult is false)
                return null;

            return new(values[0], values[1], int.Parse(values[2]), int.Parse(values[3]), 
                int.Parse(values[4]), int.Parse(values[5]), (Fuel)fuel, values[7], 
                values[8], int.Parse(values[9]), int.Parse(values[10]), values[11], 
                int.Parse(values[12]), (TruckType)type, int.Parse(values[14]));
        }
    }
}
