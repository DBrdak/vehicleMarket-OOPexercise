using Domain.Common.Enums;
using Microsoft.VisualBasic.CompilerServices;

namespace Domain.Core
{
    public class Car : Vehicle
    {
        public int Seats { get; }
        public int Doors { get; }
        public string ModelVersion { get; }
        public CarType Type { get; }

        public Car(string make, string model, int productionYear, int mileage, 
            int power, int cubicCapacity, Fuel fuelType, string city, string phoneNumber, 
            int price, int seats, int doors, string modelVersion, CarType type) 
            : base(make, model, productionYear, mileage, power, cubicCapacity, fuelType, city, phoneNumber, price)
        {
            Seats = seats;
            Doors = doors;
            ModelVersion = modelVersion;
            Type = type;
        }

        public static explicit operator Car(string[] values)
        {
            var parseResult = Enum.TryParse(typeof(Fuel), values[6], true, out var fuel);
            parseResult = Enum.TryParse(typeof(CarType), values[13], true, out var type);

            if (parseResult is false)
                return null;

            return new(values[0], values[1], int.Parse(values[2]), int.Parse(values[3]),
                int.Parse(values[4]), int.Parse(values[5]), (Fuel)fuel, values[7],
                values[8], int.Parse(values[9]), int.Parse(values[10]), int.Parse(values[11]), values[12], (CarType)type);
        }
    }
}
