using System.Text;
using Patterns.FactoryMethod.Product;

namespace Patterns.FactoryMethod.Creator;

public abstract class Vehicle
{
    public Vehicle() => CreateParts();

    public abstract string Name { get; }

    public List<Part> Parts { get; } = new List<Part>();

    // Factory Method
    public abstract void CreateParts();

    public void PrintDetails()
    {
        var detailsBuilder = new StringBuilder($"Car: {Name}");

        Parts
            .ForEach(part => detailsBuilder.Append($" | {part.PrintDetails()}"));

        Console.WriteLine(detailsBuilder.ToString());
    }
}