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
    }
}
