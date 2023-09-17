using System.Text;

namespace Huffman
{
    public static class HuffmanHelper
    {
        public static CodeTreeNode Huffman(List<CodeTreeNode> codes)
        {
            while (codes.Count > 1)
            {
                codes = codes.OrderByDescending(x => x.w).ToList();

                var l = codes.Last();
                codes.RemoveAt(codes.Count - 1);
                var r = codes.Last();
                codes.RemoveAt(codes.Count - 1);

                codes.Add(new CodeTreeNode
                {
                    w = l.w + r.w,
                    l = l,
                    r = r
                });
            }

            return codes.First();
        }

        public static Dictionary<string, string> CodeDict(List<CodeTreeNode> list, CodeTreeNode tree) =>
            list.ToDictionary(val => val.ch, val => tree.GetCode(val.ch, string.Empty));

        public static string HuffmanEncode(string text, Dictionary<string, string> codeDict) =>
            string.Join(string.Empty, from c in text select codeDict[c.ToString()]);

        public static string BigramHuffmanEncode(string text, Dictionary<string, string> codeDict)
        {
            var result = new StringBuilder();
            for (var i = 0; i < text.Length; i += 2)
            {
                var w = text[i..(i + 2)];
                result.Append(codeDict[w]);
            }

            return result.ToString();
        }

        public static string HuffmanDecode(CodeTreeNode tree, string encode)
        {
            var str = new StringBuilder();
            var node = tree;
            foreach (var c in encode)
            {
                node = c == '0' ? node.l : node.r;
                if (node.ch != default)
                {
                    str.Append(node.ch);
                    node = tree;
                }
            }

            return str.ToString();
        }

        public static Dictionary<string, double> FrecDict(string text)
        {
            var dict = new Dictionary<string, double>();
            foreach (var w in text)
            {
                var c = w.ToString();
                if (!dict.ContainsKey(c))
                    dict[c] = 1.0;
                else
                    dict[c]++;
            }

            foreach (var v in dict.Keys)
                dict[v] /= text.Length;

            return dict;
        }

        public static Dictionary<string, double> BigramFrecDict(string text)
        {
            var dict = new Dictionary<string, double>();
            for (var i = 0; i < text.Length; i+=2)
            {
                var w = text[i..(i+2)];
                if (!dict.ContainsKey(w))
                    dict[w] = 1.0;
                else
                    dict[w]++;
            }                

            foreach (var v in dict.Keys)
                dict[v] /= text.Length;

            return dict;
        }

        public static Dictionary<string, double> SavedFrecDict() => new()
        {
            [" "] = .175,
            ["а"] = .062,
            ["б"] = .014,
            ["в"] = .038,
            ["г"] = .013,
            ["д"] = .025,
            ["е"] = .072,
            ["ё"] = .072,
            ["ж"] = .007,
            ["з"] = .016,
            ["и"] = .062,
            ["й"] = .010,
            ["к"] = .028,
            ["л"] = .035,
            ["м"] = .026,
            ["н"] = .053,
            ["о"] = .090,
            ["п"] = .023,
            ["р"] = .040,
            ["с"] = .045,
            ["т"] = .053,
            ["у"] = .021,
            ["ф"] = .002,
            ["х"] = .009,
            ["ц"] = .004,
            ["ч"] = .012,
            ["ш"] = .006,
            ["щ"] = .003,
            ["ъ"] = .014,
            ["ы"] = .016,
            ["ь"] = .014,
            ["э"] = .003,
            ["ю"] = .006,
            ["я"] = .018
        };

        public static List<CodeTreeNode> ToFreqList(Dictionary<string, double> frecDict) =>
            (from x in frecDict select new CodeTreeNode { ch = x.Key, w = x.Value }).ToList();

        public static Dictionary<char, int> SortByValueDesc(this Dictionary<char, int> dict) =>
            dict.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
    }
}
