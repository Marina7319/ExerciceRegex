using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace NetherRealms
{
    class Program
    {
        static void Main(string[] args)
        {
            string healthPattern = @"[^\+\-\*\/\.,0-9]";
            string damagePatern = @"-?\d+\.?\d*";
            string multiplyDividePattern = @"[\*\/]";
            string splitPattern = @"[,\s]+";
            string[] input = Console.ReadLine().Split(", ");
            var planets = new Dictionary<string, string>();
            foreach (var inputPlanet in input)
            {
                string[] demons = Regex.Split(inputPlanet, splitPattern).OrderBy(x => x).ToArray();
                string[] damage = Regex.Split(inputPlanet, healthPattern).ToArray();
                string[] health = Regex.Split(inputPlanet, damagePatern).ToArray();
                Regex multiplyDivide = new Regex(multiplyDividePattern);
                MatchCollection multiplyAndDivide = multiplyDivide.Matches(inputPlanet);
                int points = 0;
                double sumDamage = 0;
                Regex regex = new Regex(damagePatern);
                MatchCollection matches = regex.Matches(inputPlanet);
                foreach (Match match in matches)
                {
                    double currentDamage = double.Parse(match.ToString());
                    sumDamage += currentDamage;
                }
                foreach (var chars in multiplyAndDivide)
                {
                    if (chars == "/")
                    {
                        sumDamage = sumDamage / 2;
                    }
                    else
                    {
                        sumDamage = sumDamage * 2;
                    }
                }

                foreach (var letters in health)
                {
                    if (letters.Length > 1)
                    {
                        for (int i = 0; i < letters.Length; i++)
                        {
                            if (char.IsLetter(letters[i]))
                            {
                                points += (int)letters[i];
                            }
                        }
                    }
                    else
                    {
                        char letter = char.Parse(letters);
                        if (char.IsLetter(letter))
                        {
                            points += (int)char.Parse(letters);
                        }
                    }
                }
                string result = $"{points} {sumDamage}";
                if (!planets.ContainsKey(inputPlanet))
                {
                    planets.Add(inputPlanet, result);
                }
            }
            foreach (var planet in planets.OrderBy(currDemonName => currDemonName.Key))
            {
                string[] healthDamageNums = planet.Value.Split(" ");
                Console.WriteLine($"{planet.Key} - {healthDamageNums[0]} health, {double.Parse(healthDamageNums[1]):f2} damage");
            }
        }
    }
}
