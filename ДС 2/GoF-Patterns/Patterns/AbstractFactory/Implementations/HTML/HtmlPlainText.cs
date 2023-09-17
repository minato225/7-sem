using Patterns.AbstractFactory.Interfaces;

namespace Patterns.AbstractFactory.Implementations.HTML;
public class HtmlPlainText : IPlainText
{
    public string GetPlainText(string text) => text;
}