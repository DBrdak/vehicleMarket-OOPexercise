using Domain.Common.Attributes;

namespace Domain.Common.Enums;

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