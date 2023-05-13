using Domain.Common;
using Domain.Common.Enums;
using Domain.Common.Eventing;

namespace Domain.Core
{
    public abstract class Vehicle : Sorter, IComparable<Vehicle>
    {
        private static int id = 0;
        public int Id { get; }
        public string Make { get; }
        public string Model { get; }
        public int ProductionYear { get; }
        public int Mileage { get; }
        public Technicals Technicals { get; }
        public string City { get; }
        public string PhoneNumber { get; }
        public int Price { get; }
        public event BidDelegate Bid;

        protected Vehicle(string make, string model, int productionYear, int mileage, int power, 
            int cubicCapacity, Fuel fuelType, string city, string phoneNumber, int price)
        {
            if (id >= int.MaxValue)
                id = 0;
            id++;
            Id = id;
            Make = make;
            Model = model;
            ProductionYear = productionYear;
            Mileage = mileage;
            Technicals = new Technicals(power, cubicCapacity, fuelType);
            City = city;
            PhoneNumber = phoneNumber;
            Price = price;
        }

        public int CompareTo(Vehicle other)
        {
            if(other is null) 
                return 1;

            return this.Id.CompareTo(other);
        }

        public void OnBid(int amount)
        {
            if(Bid is not null)
                Bid(this, new BidEvent(amount));
            else
                Console.WriteLine("");
        }
    }
}
