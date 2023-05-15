using Domain.Common.Enums;

namespace Domain.Core
{
    public class Motorbike : Vehicle
    {
        public DrivingType Drive { get; }
        public MotorbikeType Type { get; }

        public Motorbike(string make, string model, int productionYear, 
            int mileage, int power, int cubicCapacity, Fuel fuelType, string city, 
            string phoneNumber, int price, DrivingType drive, MotorbikeType type) 
            : base(make, model, productionYear, mileage, power, cubicCapacity, fuelType, city, phoneNumber, price)
        {
            Drive = drive;
            Type = type;
        }

        public static explicit operator Motorbike(string[] values)
        {
            var parseResult = Enum.TryParse(typeof(Fuel), values[6], true, out var fuel);
            parseResult = Enum.TryParse(typeof(DrivingType), values[10], true, out var drive);
            parseResult = Enum.TryParse(typeof(MotorbikeType), values[11], true, out var type);

            if (parseResult is false)
                return null;

            return new(values[0], values[1], int.Parse(values[2]), int.Parse(values[3]),
                int.Parse(values[4]), int.Parse(values[5]), (Fuel)fuel, values[7],
                values[8], int.Parse(values[9]), (DrivingType)drive, (MotorbikeType)type);
        }
    }
}
