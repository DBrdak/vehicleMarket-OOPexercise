using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Domain.Common;
using Domain.Common.Enums;
using Microsoft.VisualBasic.CompilerServices;

namespace Domain.Truck
{
    public class Truck : Vehicle
    {
        public int Torque { get; }
        public int GVW { get; }
        [RegularExpression("^\\d+x\\d+x\\d+$")]
        public string LoadSizeCapacity { get; }
        public int Axles { get; }
        public TruckType Type { get; }

        public Truck(string make, string model, int productionYear, int mileage,
            int power, int cubicCapacity, Fuel fuelType, string city, string phoneNumber,
            int price, int torque, int gvw, string loadSizeCapacity, int axles, TruckType type)
            : base(make, model, productionYear, mileage, power, cubicCapacity, fuelType, city, phoneNumber, price)
        {
            (Torque, GVW, LoadSizeCapacity, Axles, Type) = (torque, gvw, loadSizeCapacity, axles, type);
        }

        public override string ToDetailedString() =>
            base.ToDetailedString() + $"\nMoment obrotowy: {Torque}Nm\n" +
            $"DMC: {GVW}kg\nWymiary zabudowy: {LoadSizeCapacity}\nLiczba osi: {Axles}\nRodzaj zabudowy: {Type.ToTranslatedString()}";
    }
}
