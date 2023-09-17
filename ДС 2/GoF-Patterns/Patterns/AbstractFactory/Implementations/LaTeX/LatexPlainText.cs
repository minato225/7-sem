using Patterns.AbstractFactory.Interfaces;

namespace Patterns.AbstractFactory.Implementations.LaTeX;

public class LatexPlainText : IPlainText
{
    public string GetPlainText(string text) => text;
}