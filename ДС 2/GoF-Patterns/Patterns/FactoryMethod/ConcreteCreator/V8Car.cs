using Patterns.FactoryMethod.ConcreteProduct;
using Patterns.FactoryMethod.Creator;

namespace Patterns.FactoryMethod.ConcreteCreator;

public class V8Car : Vehicle
{
    public override string Name => nameof(V8Car);

    public override void CreateParts()
    {
        Parts.Add(new Engine(EngineType.V8));
        Parts.Add(new Seat(2));
        Parts.Add(new Wheel(4));
    }
}