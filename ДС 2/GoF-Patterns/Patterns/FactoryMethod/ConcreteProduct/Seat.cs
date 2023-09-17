using Patterns.FactoryMethod.Product;

namespace Patterns.FactoryMethod.ConcreteProduct;

public class Seat : Part
{
    public Seat(int total) => TotalSeats = total;

    public int TotalSeats { get; set; }

    public override string PrintDetails() => $"Number of Seats: {TotalSeats}";
}