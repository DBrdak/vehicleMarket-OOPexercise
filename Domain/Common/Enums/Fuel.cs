using Domain.Common.Attributes;

namespace Domain.Common.Enums;

public enum Fuel
{
    [TranslatedName("Benzyna")]
    Petrol,
    Diesel,
    [TranslatedName("Elektryczny")]
    Electric,
    [TranslatedName("Hybryda")]
    Hybrid,
    LPG
}