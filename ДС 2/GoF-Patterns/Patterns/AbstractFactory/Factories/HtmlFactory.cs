using Patterns.AbstractFactory.Implementations.HTML;
using Patterns.AbstractFactory.Interfaces;

namespace Patterns.AbstractFactory.Factories;

public class HtmlFactory : ITextFactory
{
    public IBoldText BoldFormat() => new HtmlBoldText();

    public IHyperlink HyperlinkFormat() => new HtmlHyperlink();

    public IPlainText PlainFormat() => new HtmlPlainText();
}