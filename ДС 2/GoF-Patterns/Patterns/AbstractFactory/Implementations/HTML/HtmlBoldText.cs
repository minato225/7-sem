using Patterns.AbstractFactory.Interfaces;

namespace Patterns.AbstractFactory.Implementations.HTML;
public class HtmlBoldText : IBoldText
{
    public string GetBoldText(string text) => $"<b>{text}</b>";
}