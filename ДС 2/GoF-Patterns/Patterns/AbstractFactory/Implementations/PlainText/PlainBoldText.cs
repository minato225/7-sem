using Patterns.AbstractFactory.Interfaces;
namespace Patterns.AbstractFactory.Implementations.PlainText;

public class PlainBoldText : IBoldText
{
    public string GetBoldText(string text) => $"**{text}**";
}