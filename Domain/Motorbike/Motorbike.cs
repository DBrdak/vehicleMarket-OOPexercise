using Domain.Common;
using Domain.Common.Enums;

namespace Domain.Motorbike
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
            (Drive, Type) = (drive, type);
        }
        public override string ToDetailedString() =>
            base.ToDetailedString() + $"\nRodzaj napędu: {Drive.ToTranslatedString()}\nTyp motocykla: {Type.ToTranslatedString()}";
    }
}
