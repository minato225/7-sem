using Patterns.AbstractFactory.Implementations.PlainText;
using Patterns.AbstractFactory.Interfaces;

namespace Patterns.AbstractFactory.Factories;

public class PlainTextFactory : ITextFactory
{
    public IBoldText BoldFormat() => new PlainBoldText();

    public IHyperlink HyperlinkFormat() => new PlainHyperlink();

    public IPlainText PlainFormat() => new PlainText();
}