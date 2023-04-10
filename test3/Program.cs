using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {


    }

    public static IDictionary<string, string> MorseCodeDictionary = new Dictionary<string, string>()
    {
        { ".-", "A" }, { "-...", "B" }, { "-.-.", "C" }, { "-..", "D" },
        { ".", "E" }, { "..-.", "F" }, { "--.", "G" }, { "....", "H" },
        { "..", "I" }, { ".---", "J" }, { "-.-", "K" }, { ".-..", "L" },
        { "--", "M" }, { "-.", "N" }, { "---", "O" }, { ".--.", "P" },
        { "--.-", "Q" }, { ".-.", "R" }, { "...", "S" }, { "-", "T" },
        { "..-", "U" }, { "...-", "V" }, { ".--", "W" }, { "-..-", "X" },
        { "-.--", "Y" }, { "--..", "Z" },{ "...---...", "SOS" },
    };


}