using Patterns.AbstractFactory.Interfaces;

namespace Patterns.AbstractFactory.Implementations.LaTeX;

public class LatexHyperlink : IHyperlink
{
    public string GetHyperlink(string text, string uri) => $"\\href{{{uri}}}{{{text}}}";
}