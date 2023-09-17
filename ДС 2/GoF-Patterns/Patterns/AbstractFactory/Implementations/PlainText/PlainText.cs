using Patterns.AbstractFactory.Interfaces;

namespace Patterns.AbstractFactory.Implementations.PlainText;

public class PlainText : IPlainText
{
    public string GetPlainText(string text) => text;
}