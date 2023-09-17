using Patterns.AbstractFactory.Interfaces;

namespace Patterns.AbstractFactory;
public interface ITextFactory
{
    IBoldText BoldFormat();

    IHyperlink HyperlinkFormat();

    IPlainText PlainFormat();
}