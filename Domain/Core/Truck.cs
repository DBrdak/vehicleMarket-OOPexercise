using System.ComponentModel.DataAnnotations;
using Domain.Common.Enums;

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
    }
}
