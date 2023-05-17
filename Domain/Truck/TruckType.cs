using Domain.Common.Attributes;

namespace Domain.Truck;

public enum TruckType
{
    [TranslatedName("Ciężarówka kontenerowa")]
    ContainerTruck,
    [TranslatedName("Wywrotka")]
    DumpTruck,
    [TranslatedName("Platforma")]
    FlatbedTruck,
    [TranslatedName("Skrzynia")]
    BoxTruck,
    [TranslatedName("Chłodnia")]
    RefrigeratedTruck,
    [TranslatedName("Cysterna")]
    TankerTruck,
    [TranslatedName("Laweta")]
    TowTruck,
    [TranslatedName("Betoniarka")]
    ConcreteMixerTruck,
    [TranslatedName("Ciężarówka do drewna")]
    TimberTruck,
    [TranslatedName("Śmieciarka")]
    GarbageTruck
}