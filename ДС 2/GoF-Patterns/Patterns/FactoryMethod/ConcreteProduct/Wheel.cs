using Patterns.FactoryMethod.Product;

namespace Patterns.FactoryMethod.ConcreteProduct;

public class Wheel : Part
{
    public Wheel(int quantity) => Quantity = quantity;

    public int Quantity { get; set; }

    public override string PrintDetails() => $"Number of Wheels: {Quantity}";
}