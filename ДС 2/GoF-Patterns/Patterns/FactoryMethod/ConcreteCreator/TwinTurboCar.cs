using Patterns.FactoryMethod.ConcreteProduct;
using Patterns.FactoryMethod.Creator;

namespace Patterns.FactoryMethod.ConcreteCreator;


public class TwinTurboCar : Vehicle
{
    public override string Name => nameof(TwinTurboCar);

    public override void CreateParts()
    {
        Parts.Add(new Engine(EngineType.TwinTurbo));
        Parts.Add(new Seat(4));
        Parts.Add(new Wheel(4));
    }
}