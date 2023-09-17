namespace Patterns.AbstractFactory;

public class Document
{
    private readonly ITextFactory factory;

    public Document(ITextFactory factory) => 
        this.factory = factory ?? throw new ArgumentNullException(nameof(factory));

    public string BoldText(string text) => factory.BoldFormat().GetBoldText(text);

    public string HyperlinkText(string text, string uri) => factory.HyperlinkFormat().GetHyperlink(text, uri);

    public string PlainText(string text) => factory.PlainFormat().GetPlainText(text);
}
