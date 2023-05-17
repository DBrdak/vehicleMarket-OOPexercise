using Domain.Common.Attributes;

namespace Domain.Car;

public enum CarType
{
    Hatchback,
    Sedan,
    [TranslatedName("Kombi")]
    EstateCar,
    SUV,
    Coupe,
    [TranslatedName("Karbriolet")]
    Cabrio,
    Minivan,
    Pickup,
    [TranslatedName("Limuzyna")]
    Limousine,
    OffRoad
}