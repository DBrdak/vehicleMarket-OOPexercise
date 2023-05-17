using Domain.Common.Attributes;

namespace Domain.Motorbike;

public enum DrivingType
{
    [TranslatedName("Łańcuch")]
    Chain,
    [TranslatedName("Wał kardana")]
    Shaft,
    [TranslatedName("Pasek")]
    Belt
}