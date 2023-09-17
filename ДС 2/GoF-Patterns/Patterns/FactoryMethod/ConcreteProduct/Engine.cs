using Patterns.FactoryMethod.Product;

namespace Patterns.FactoryMethod.ConcreteProduct;

public class Engine : Part
{
    public Engine(EngineType type) => Type = type;

    public EngineType Type { get; set; }

    public override string PrintDetails() => $"Type: {Type}";
}