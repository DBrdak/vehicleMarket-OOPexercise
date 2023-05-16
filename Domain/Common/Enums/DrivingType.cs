using Domain.Common.Attributes;

namespace Domain.Common.Enums;

public enum DrivingType
{
    [TranslatedName("Łańcuch")]
    Chain,
    [TranslatedName("Wał kardana")]
    Shaft,
    [TranslatedName("Pasek")]
    Belt
}