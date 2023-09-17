using Patterns.AbstractFactory.Interfaces;

namespace Patterns.AbstractFactory.Implementations.PlainText;

public class PlainHyperlink : IHyperlink
{
    public string GetHyperlink(string text, string uri) => $"{text} [{uri}]";
}