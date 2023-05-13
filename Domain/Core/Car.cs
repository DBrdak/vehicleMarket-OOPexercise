﻿using Domain.Common.Enums;
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
    }
}