using Patterns.AbstractFactory.Implementations.LaTeX;
using Patterns.AbstractFactory.Interfaces;

namespace Patterns.AbstractFactory.Factories;

public class LatexFactory : ITextFactory
{
    public IBoldText BoldFormat() => new LatexBoldText();

    public IHyperlink HyperlinkFormat() => new LatexHyperlink();

    public IPlainText PlainFormat() => new LatexPlainText();
}