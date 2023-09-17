using Huffman;

namespace Lab4;
public static class HuffmanExtensions
{
    public static void Analise(this string text, bool isLoaded)
    {
        Console.WriteLine("Onegram Analise");
        var freqDict = isLoaded ? HuffmanHelper.FrecDict(text) : HuffmanHelper.SavedFrecDict();
        var list = HuffmanHelper.ToFreqList(freqDict);

        var tree = HuffmanHelper.Huffman(list);
        var codeDict = HuffmanHelper.CodeDict(list, tree);
        var encoded = HuffmanHelper.HuffmanEncode(text, codeDict);
        var decoded = HuffmanHelper.HuffmanDecode(tree, encoded);
        var average = list.Sum(c => freqDict[c.ch] * codeDict[c.ch].Length);
        var entropy = -(from x in freqDict select x.Value / text.Length).Sum(x => x * Math.Log2(x));

        PrintInfo(list, codeDict, text, encoded, decoded, average, entropy);
    }

    public static void BigramAnalise(this string text)
    {
        Console.WriteLine("Bigram Analise");
        var bigramFreqDict = HuffmanHelper.BigramFrecDict(text);
        var list = HuffmanHelper.ToFreqList(bigramFreqDict);

        var tree = HuffmanHelper.Huffman(list);
        var codeDict = HuffmanHelper.CodeDict(list, tree);
        var encoded = HuffmanHelper.BigramHuffmanEncode(text, codeDict);
        var decoded = HuffmanHelper.HuffmanDecode(tree, encoded);

        var average = list.Sum(c => bigramFreqDict[c.ch] * codeDict[c.ch].Length);
        var entropy = -(from x in bigramFreqDict select x.Value / text.Length).Sum(x => x * Math.Log2(x));

        PrintInfo(list, codeDict, text, encoded, decoded, average, entropy);
    }

    private static void PrintInfo(List<CodeTreeNode> list, Dictionary<string, string> codeDict, string text, string encoded, string decoded, double average, double entropy) => 
        Console.WriteLine($"""
            Frec List
            {string.Join('\n', list)}
            Code Page
            {string.Join('\n', codeDict)}
            Source memory = {text.Length * 8} bit
            Zip memory = {encoded.Length} bit
            Compression = {text.Length * 8.0 / encoded.Length} times
            text = {text[..50]}
            encoded = {encoded[..50]}
            decoded = {decoded[..50]}
            Avarage Length = {average}
            Entropy = {entropy}
            """);
}
