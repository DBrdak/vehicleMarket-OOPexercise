using System.ComponentModel.DataAnnotations;
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
        public int Power { get; }
        public int CubicCapacity { get; }
        public Fuel FuelType { get; }
        public string City { get; }
        [RegularExpression("^\\+\\d{1,3}\\d{9}$")]
        public string PhoneNumber { get; }
        public int Price { get; }

        public event BidDelegate Bid;

        protected Vehicle(string make, string model, int productionYear, int mileage, int power, 
            int cubicCapacity, Fuel fuelType, string city, string phoneNumber, int price)
        {
            if (id >= int.MaxValue)
                id = 0;

            id++;

            (Id, Make, Model, ProductionYear, Mileage, Power, CubicCapacity, FuelType, City, PhoneNumber, Price) = 
                (id, make, model, productionYear, mileage, power,cubicCapacity, fuelType, city, phoneNumber, price);
        }

        public int CompareTo(Vehicle other)
        {
            if(other is null) 
                return 1;

            return this.Id.CompareTo(other.Id);
        }

        public void OnBid(int amount)
        {
            if(Bid is not null)
                Bid(this, new BidEvent(amount));
            else
                Console.WriteLine("Error while making bid");
        }

        public override string ToString() =>
            $"{$"({Id})",-7} {Make, -15} {Model, -20} {ProductionYear, -13} {Mileage, -12} {Price, -12}";

        public virtual string ToDetailedString() =>
            $"Marka: {Make}\nModel: {Model}\nRok produkcji: {ProductionYear}\nPrzebieg: {Mileage}km\n" +
            $"Moc: {Power}KM\nPojemność skokowa: {CubicCapacity}ccm\nRodzaj paliwa: {FuelType}\n" +
            $"Miasto: {City}\nNumer telefonu do sprzedającego: {PhoneNumber}\nCena: {Price}";
    }
}
