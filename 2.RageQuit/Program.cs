using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace RageQuit
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<char> uniqueSymbols = new List<char>();
            string pattern = @"(?<lett>\D+)+(?<number>\d+)+";
            Regex regex = new Regex(pattern);
            MatchCollection lettWithNumbers = regex.Matches(input);
            string result = "";
            foreach (Match x in lettWithNumbers)
            {
                string lett = x.Groups["lett"].Value; 
                string number = x.Groups["number"].Value; 
                for (int i = 0; i < int.Parse(number.ToString()); i++)
                {
                    result += lett;
                }
            }
            string lowerToUpper = result.ToUpper();
            for(int currentChar = 0; currentChar < lowerToUpper.Length; currentChar++)
            {
                if (!uniqueSymbols.Contains(lowerToUpper[currentChar]))
                { 
                    uniqueSymbols.Add(lowerToUpper[currentChar]);
                }
            }
            Console.WriteLine($"Unique symbols used: {uniqueSymbols.Count}");
            Console.WriteLine(lowerToUpper.ToUpper());
        }
    }
}
