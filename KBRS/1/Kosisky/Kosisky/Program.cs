using Kasisky;

var keys = new[] { "ac", "hey", "word", "hello", "safari", "encrypt", "abstract", "yesterday", "flycatcher", "oppositions" };

for (var i = 0; i < 8; i++)
{
    var text = File.ReadAllText($"./Texts/{i}.txt").ToUpper();
    text = Constants.NonlettersPattern.Replace(text, string.Empty);
    foreach (var key in keys)
    {
        var encryptText = VigenreCipher.Encrypt(text, key);
        var (resultKey, succes) = Kasiski.Attack(encryptText, text);
        var result = succes ? "Success" : "Failed";
        Console.WriteLine($"text {i} real key = \"{key}\" result key = \"{resultKey}\" => result: {result}");
    }

    Console.WriteLine();
}
