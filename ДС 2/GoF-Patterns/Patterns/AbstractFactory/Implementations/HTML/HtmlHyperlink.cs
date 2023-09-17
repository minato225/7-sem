using Patterns.AbstractFactory.Interfaces;

namespace Patterns.AbstractFactory.Implementations.HTML;
public class HtmlHyperlink : IHyperlink
{
    public string GetHyperlink(string text, string uri) => $"<a href=\"{uri}\">{text}</a>";
}