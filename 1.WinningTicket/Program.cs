using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace WinningTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries).ToArray();
            foreach (var currInputLine in input)
            {
                string removeSpaces = currInputLine.Trim();
                int currInputLength = removeSpaces.Length;
                if (currInputLength == 20)
                {

                    string firstInput = "";
                    for (int i = 0; i < 10; i++)
                    {
                        firstInput += removeSpaces[i];
                    }
                    string secondInput = "";
                    for (int j = 10; j < 20; j++)
                    {
                        secondInput += removeSpaces[j];
                    }

                    string pattern = @"[@$#^]{5}[@$#^]+";//@"[@$#^]{6}[@$#^]*";
                    Regex regex = new Regex(pattern);
                    Match matcheFirst = regex.Match(firstInput);
                    Match matcheSecond = regex.Match(secondInput);
                    if (matcheFirst.Success && matcheSecond.Success && matcheFirst.ToString() == matcheSecond.ToString())
                    {
                        string matchToString = matcheFirst.ToString();
                        int ticketSymbolsNum = matchToString.Length;
                        if (ticketSymbolsNum == 10)
                        {
                            Console.WriteLine($"ticket \"{removeSpaces}\" - {ticketSymbolsNum}{matchToString[0]} Jackpot!");
                        }
                        else
                        {
                            Console.WriteLine($"ticket \"{removeSpaces}\" - {ticketSymbolsNum}{matchToString[0]}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"ticket \"{removeSpaces}\" - no match");
                    }
                }
                else
                {
                    Console.WriteLine("invalid ticket");
                }
            }
        }
    }
}


