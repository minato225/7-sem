using Lab4;
using System.Text.RegularExpressions;

var text = Regex.Replace(File.ReadAllText("text.txt").ToLower(), "(?i)[^А-ЯЁа-яё ]", string.Empty);
var bigText = Regex.Replace(File.ReadAllText("big_text.txt").ToLower(), "(?i)[^А-ЯЁа-яё ]", string.Empty);

text.Analise(isLoaded: true);
text.Analise(isLoaded: false);

Console.WriteLine("""

================================================ BIG TEXT ================================================

""");

bigText.Analise(isLoaded: false);
bigText.BigramAnalise();