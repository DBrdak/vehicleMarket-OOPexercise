using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Car;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Motorbike;
using Domain.Truck;

namespace Application.Data
{
    public static class DataContext
    {
        public static List<Vehicle> Vehicles = new();

        static DataContext()
        {
            Seed();
        }

        private static void Seed()
        {
            var vehicles = new List<Vehicle>
            {
                new Truck("Daf", "XF", 2012, 765192, 490, 12900, Fuel.Diesel, "Katowice", "+48701234567", 18900, 2500, 26600, "1360x240x250", 3, TruckType.RefrigeratedTruck),
                new Car("BMW", "Serie 3", 2015, 127612, 240, 2000, Fuel.Petrol, "Poznań", "+48502430221", 102900, 5, 4, "F30 328i", CarType.Sedan),
                new Motorbike("Honda", "Fury", 2011, 16059, 58, 1312, Fuel.Petrol, "Olsztyn", "+48236170092", 23901, DrivingType.Shaft, MotorbikeType.Cruiser),
                new Truck("Volvo", "FH", 2014, 820145, 500, 14700, Fuel.Diesel, "Gdańsk", "+48787878787", 25900, 8000, 40000, "1360x260x270", 2, TruckType.FlatbedTruck),
                new Car("Audi", "A4", 2018, 40562, 190, 2000, Fuel.Petrol, "Warszawa", "+48666123456", 129000, 5, 4, "B9 35 TFSI", CarType.Sedan),
                new Motorbike("Kawasaki", "Ninja H2R", 2021, 20, 310, 998, Fuel.Petrol, "Kraków", "+48723896541", 380000, DrivingType.Chain, MotorbikeType.Sportbike),
                new Truck("MAN", "TGS", 2016, 912345, 440, 11500, Fuel.Diesel, "Łódź", "+48601829584", 149000, 3500, 28000, "2200x240x240", 3, TruckType.BoxTruck),
                new Car("Volkswagen", "Golf", 2019, 27000, 115, 1000, Fuel.Petrol, "Gdynia", "+48504725310", 62000, 5, 5, "Mk7 1.0 TSI", CarType.Hatchback),
                new Motorbike("Harley-Davidson", "Softail Slim", 2020, 750, 64, 1745, Fuel.Petrol, "Wrocław", "+48777777777", 69000, DrivingType.Belt, MotorbikeType.Cruiser),
                new Truck("Scania", "R500", 2010, 651234, 500, 12000, Fuel.Diesel, "Katowice", "+48774455632", 123000, 2000, 25000, "1360x250x250", 3, TruckType.DumpTruck),
                new Car("Mercedes-Benz", "E-Class", 2016, 87000, 184, 2000, Fuel.Diesel, "Poznań", "+48715123456", 139000, 5, 4, "W213 E220d", CarType.Sedan),
                new Motorbike("Yamaha", "MT-07", 2018, 12500, 75, 689, Fuel.Petrol, "Gdańsk", "+48736654432", 25500, DrivingType.Chain, MotorbikeType.Naked),
                new Truck("Iveco", "Eurocargo", 2017, 512345, 210, 7500, Fuel.Diesel, "Warszawa", "+48601122334", 97000, 2000, 15000, "630x220x240", 2, TruckType.ContainerTruck),
                new Truck("Mercedes-Benz", "Actros", 2018, 845230, 430, 18000, Fuel.Diesel, "Warsaw", "+48221234567", 145000, 10000, 31000, "2500x250x800", 2, TruckType.DumpTruck),
                new Car("Audi", "A4", 2020, 31455, 190, 2000, Fuel.Petrol, "Krakow", "+48662123456", 142500, 5, 4, "B9 2.0 TFSI quattro", CarType.Sedan),
                new Motorbike("Harley-Davidson", "Sportster Iron 883", 2019, 2032, 50, 883, Fuel.Petrol, "Gdansk", "+48771234567", 38999, DrivingType.Chain, MotorbikeType.Cruiser),
                new Truck("Volvo", "FH", 2017, 721908, 540, 12000, Fuel.Diesel, "Lodz", "+48662345678", 110000, 14000, 21000, "1200x240x250", 2, TruckType.ContainerTruck),
                new Car("Volkswagen", "Golf", 2018, 57230, 115, 1600, Fuel.Diesel, "Wroclaw", "+48791234567", 68900, 5, 4, "Mk7 1.6 TDI", CarType.Hatchback),
                new Motorbike("Kawasaki", "Ninja ZX-10R", 2021, 135, 203, 1000, Fuel.Petrol, "Poznan", "+48505678901", 78900, DrivingType.Chain, MotorbikeType.Sportbike),
                new Truck("MAN", "TGX", 2020, 923472, 500, 20000, Fuel.Diesel, "Gdansk", "+48771234567", 178000, 3000, 36000, "1360x260x250", 3, TruckType.RefrigeratedTruck),
                new Car("Ford", "Mustang", 2015, 87562, 435, 5000, Fuel.Petrol, "Katowice", "+48601234567", 129900, 2, 2, "S550 GT 5.0 V8", CarType.Coupe),
                new Motorbike("Ducati", "Monster 821", 2018, 1587, 109, 821, Fuel.Petrol, "Warsaw", "+48505678901", 39900, DrivingType.Chain, MotorbikeType.Naked),
                new Truck("Iveco", "Stralis", 2019, 672395, 460, 16000, Fuel.Diesel, "Krakow", "+48771234567", 135000, 8000, 26000, "2500x240x800", 2, TruckType.FlatbedTruck),
                new Car("Toyota", "Corolla", 2021, 2190, 116, 1600, Fuel.Hybrid, "Lodz", "+48601234567", 93900, 5, 4, "E210 Hybrid 1.6", CarType.Sedan)
            };

            Vehicles.AddRange(vehicles);
        }
    }
}
