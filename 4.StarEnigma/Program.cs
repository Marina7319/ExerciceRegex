using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace StarEnigma
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(?<name>[A-z]+)[^@\-!:>]*:(?<population>[\d]+)[^@\-!:>]*!(?<type>[A,D])![^@\-!:>]*->(?<count>[\d]+)";
            int listOfInput = int.Parse(Console.ReadLine());
            var attacked = new List<string>();
            var destroyed = new List<string>();
            for (int i = 0; i < listOfInput; i++)
            {
                string message = Console.ReadLine();
                int sum = message.ToLower().Count(x => x == 's' || x == 't' || x == 'a' || x == 'r');
                Regex regex = new Regex(pattern);
                Match matches = Regex.Match(message, pattern: pattern, RegexOptions.IgnoreCase);
                Console.WriteLine(matches);
            }
        }
    }
}
