using System.Collections.Immutable;
using System.Text;

namespace Kasisky;
public class Kasiski
{
    public static (string resultKey, bool succes) Attack(string cipherText, string text)
    {
        var keyLengths = KasiskiExamination(cipherText);
        keyLengths.Sort();
        var key = new StringBuilder();
        text = text.ToUpper();

        foreach (var keyLength in keyLengths)
        {
            var intendedKey = AttackWithKeyLength(cipherText, keyLength);

            var deshipher = VigenreCipher.Decrypt(cipherText, intendedKey);
            if (text == deshipher)
                return (intendedKey.ToLower(), true);

            key.Append(intendedKey).Append(' ');
        }

        return (key.ToString().Trim().ToLower(), false);
    }

    // AttackWithKeyLength
    private static string AttackWithKeyLength(string cipherText, int keyLength)
    {
        var posKey = new char[keyLength];
        for (var i = 0; i < keyLength; i++)
        {
            var nthLetters = GetNthSubkeysLetters(i, keyLength, cipherText);
            posKey[i] = GetMostFrequencyChar(nthLetters);
        }

        return new string(posKey);
    }
    private static string GetNthSubkeysLetters(int n, int keyLength, string message)
    {
        var outputBuffer = new StringBuilder();
        for (var i = n; i < message.Length; i += keyLength)
        {
            outputBuffer.Append(message[i]);
        }

        return outputBuffer.ToString();
    }
    private static char GetMostFrequencyChar(string message)
    {
        var output = new StringBuilder(26);
        var letterFreqency = Constants.Alphabet.ToDictionary(c => c, c => 0);
        foreach (var c in message)
            letterFreqency[c]++;

        var encryptChar = letterFreqency.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;
        return Constants.Alphabet[(encryptChar - 'E' + 26) % 26];
    }

    // KasiskiExamination
    private static List<int> KasiskiExamination(string cipherText)
    {
        var normalizeText = Constants.NonlettersPattern.Replace(cipherText, string.Empty);
        var seqSpacing = FindRepeatSequences(normalizeText);
        var seqList = from seq in seqSpacing.Values
                      from spacing in seq
                      select GetFactors(spacing);

        return (from key in GetMostCommonFactors(seqList)
                orderby key.Value descending
                select key.Key)
                 .Take(3)
                 .ToList();
    }
    private static Dictionary<string, List<int>> FindRepeatSequences(string cipherText)
    {
        var output = new Dictionary<string, List<int>>();

        for (var j = 0; j < cipherText.Length - 3; j++)
        {
            var currSeq = cipherText[j..(j + 3)];
            var seqPos = cipherText.IndexOf(currSeq, startIndex: j + 1);
            while (seqPos > 0)
            {
                var length = seqPos - j;

                if (!output.ContainsKey(currSeq))
                    output[currSeq] = new();

                if (!output[currSeq].Contains(length))
                    output[currSeq].Add(length);

                seqPos = cipherText.IndexOf(currSeq, startIndex: seqPos + 1);
            }
        }

        return output;
    }
    public static IEnumerable<int> GetFactors(int x)
    {
        for (int i = 2; i * i <= x; i++)
        {
            if (x % i == 0)
            {
                yield return i;
                if (i != x / i)
                    yield return x / i;
            }
        }
    }
    private static Dictionary<int, int> GetMostCommonFactors(IEnumerable<IEnumerable<int>> factors)
    {
        var output = new Dictionary<int, int>();

        foreach (var factor in factors.SelectMany(x => x))
        {
            if (output.ContainsKey(factor))
                output[factor]++;
            else
                output[factor] = 1;
        }

        return output;
    }
}
