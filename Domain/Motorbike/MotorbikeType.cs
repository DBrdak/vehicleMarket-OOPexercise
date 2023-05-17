using Domain.Common.Attributes;

namespace Domain.Motorbike;

public enum MotorbikeType
{
    [TranslatedName("Motocykl sportowy")]
    Sportbike,
    Cruiser,
    [TranslatedName("Motocykl turystyczny")]
    Touring,
    Enduro,
    [TranslatedName("Skuter")]
    Scooter,
    OffRoad,
    [TranslatedName("Trójkołowiec")]
    Trike,
    Naked
}