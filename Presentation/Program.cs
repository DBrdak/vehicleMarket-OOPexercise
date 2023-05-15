using Application.Data;
using Application.Repositories;
using Domain.Common.Enums;
using Domain.Core;

namespace Presentation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var s = new []{ "Kawasaki", "Ninja H2R", "2021", "20", "310", "998", "Petrol", "Kraków", "+48723896541", "380000", "Chain", "Sportbike"};
            new Repository<Motorbike>().AddNew((Motorbike)s);
            var a = DataContext.Vehicles;
            Console.WriteLine("Hello, World!");
        }
    }
}