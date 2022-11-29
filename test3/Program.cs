using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        // Stb(1,9)
        var morseCode = "  .    .    .";
        //if (morseCode == "...-- - ...") encode

        var encodedMessage = Regex.Replace(morseCode, @"[\.-]+ {0,2}", x => MorseCodeDictionary[x.Value.TrimEnd()]);
        string o = encodedMessage.TrimStart(' ');
        o = o.TrimEnd(' ');
        //return encodedMessage;
        Console.WriteLine(o);

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