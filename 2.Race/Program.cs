using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Race
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex patternForName = new Regex(pattern: @"(?<name>[A-Za-z])");
            string patternForDigit = @"(?<digits>[1-9])";
            var participants = new Dictionary<string, int>();
            int sumOfDigits = 0;
            var names = Console.ReadLine().Split(separator: ", ").ToList();
            string input = Console.ReadLine();
            while (input != "end of race")
            {
                MatchCollection matchedNames = patternForName.Matches(input);
                MatchCollection matchedDigits = Regex.Matches(input, patternForDigit);
                string currName = string.Join("", matchedNames);
                string currDigit = string.Join("", matchedDigits);
                sumOfDigits = 0;
                for (int i = 0; i < currDigit.Length; i++)
                {
                    sumOfDigits += int.Parse(currDigit[i].ToString());
                }
                if (names.Contains(currName))
                {
                    if (!participants.ContainsKey(currName))
                    {
                        participants.Add(currName, sumOfDigits);
                    }
                    else
                    {
                        participants[currName] += sumOfDigits;
                    }
                }
                input = Console.ReadLine();
            }
            var winners = participants.OrderByDescending(x => x.Value).Take(3);
            var firstPlace = winners.Take(1);
            var secondPlace = winners.OrderByDescending(x => x.Value).Take(2).OrderBy(x => x.Value).Take(1);
            var thirdPlace = winners.OrderBy(x => x.Value).Take(1);
            foreach (var firstName in firstPlace)
            {
                Console.WriteLine($"1st place: {firstName.Key}");
            }
            foreach (var secondName in secondPlace)
            {
                Console.WriteLine($"2nd place: " + secondName.Key);
            }
            foreach (var thirdName in thirdPlace)
            {
                Console.WriteLine($"3rd place: " + thirdName.Key);
            }
        }
    }
}

