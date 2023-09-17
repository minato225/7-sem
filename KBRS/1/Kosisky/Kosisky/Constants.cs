using System.Text.RegularExpressions;
namespace Kasisky;

public static class Constants
{
    public static readonly Regex NonlettersPattern = new("[^A-Z]", RegexOptions.Compiled);

    public const int AlphabetLength = 26;
    public const int MaxKeyLength = 12;
    public const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
}