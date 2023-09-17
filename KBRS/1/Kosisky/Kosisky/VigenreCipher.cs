using System.Text;

namespace Kasisky;
public static class VigenreCipher
{
    public static string Encrypt(string text, string key)
    {
        var output = new StringBuilder(text.Length);
        var keyIndex = 0;
        key = key.ToUpper();

        foreach (var c in text)
        {
            var cPos = Constants.Alphabet.IndexOf(c);
            var shiftedCharPos = Constants.Alphabet.IndexOf(key[keyIndex]);

            var charPos = (cPos + shiftedCharPos) % Constants.AlphabetLength;

            output.Append(Constants.Alphabet[charPos]);
            keyIndex = (keyIndex + 1) % key.Length;
        }

        return output.ToString();
    }

    public static string Decrypt(string cipherText, string key)
    {
        var output = new StringBuilder(cipherText.Length);
        var keyIndex = 0;
        key = key.ToUpper();

        foreach (var c in cipherText)
        {
            var cPos = Constants.Alphabet.IndexOf(c);
            var shiftedCharPos = Constants.Alphabet.IndexOf(key[keyIndex]);
            cPos = (cPos - shiftedCharPos) % Constants.AlphabetLength;

            if (cPos < 0)
                cPos += Constants.Alphabet.Length;

            output.Append(Constants.Alphabet[cPos]);
            keyIndex = (keyIndex + 1) % key.Length;
        }

        return output.ToString();
    }
}
