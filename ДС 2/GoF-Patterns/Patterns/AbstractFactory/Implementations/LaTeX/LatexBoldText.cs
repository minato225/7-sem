using Patterns.AbstractFactory.Interfaces;

namespace Patterns.AbstractFactory.Implementations.LaTeX;

public class LatexBoldText : IBoldText
{
    public string GetBoldText(string text) => $"\\textbf{{{text}}}";
}