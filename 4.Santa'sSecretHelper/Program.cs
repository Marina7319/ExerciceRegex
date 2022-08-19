using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Santa_sSecretHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            String pattern = @"\w|\W";
            int keyNumber = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            var names = new Dictionary<string, char>();
            while (input != "end")
            {
                string message = input;

                Regex regex = new Regex(pattern);
                MatchCollection messageChars = regex.Matches(message);
                string result = "";
                foreach (Match chars in messageChars)
                {
                    string charsToString = chars.ToString();
                    char letter = char.Parse(charsToString);
                    int decryptedMessage = (int)letter - keyNumber;
                    result += (char)decryptedMessage;
                }
                string namePattern = @"[@]+(?<name>[A-Z][a-z]+)";
                Regex nameRegex = new Regex(namePattern);
                MatchCollection matchName = nameRegex.Matches(result);
                string letterPattern = @"!+(?<letter>[G|N]{1})!+";
                Regex letterRegex = new Regex(letterPattern);
                MatchCollection matchLetter = letterRegex.Matches(result);
                foreach (Match lett in matchLetter)
                {
                    var letter = lett.Groups["letter"].Value;
                    string goodOrBad = letter.ToString();
                    if (goodOrBad == "G")
                    {
                        foreach (Match match in matchName)
                        {
                            var name = match.Groups["name"].Value;
                            Console.WriteLine(name);
                        }
                    }
                }
                input = Console.ReadLine();
            }
        }
    }
}

