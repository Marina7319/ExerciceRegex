using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniBarIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"%(?<customer>[A-Z][a-z]+)%[^|$%.]*<(?<product>[\w]+)>[^|$%.]*\|(?<quantity>[\d]+)\|[^^|$%.]*?(?<price>[\d]+[.]?[\d]+)[][^|$%.]*(?<dollar>[$]+)";
            string input = Console.ReadLine();
            var customerList = new Dictionary<string, string>();
            double totalIncome = 0;
            while (input != "end of shift")
            {
                Regex regex = new Regex(pattern);
                bool isValid = regex.IsMatch(input);
                if (isValid)
                {
                    string customer = regex.Match(input).Groups["customer"].Value;
                    string product = regex.Match(input).Groups["product"].Value;
                    string quantity = regex.Match(input).Groups["quantity"].Value;
                    string price = regex.Match(input).Groups["price"].Value;
                    string dollar = regex.Match(input).Groups["dollar"].Value;
                    if (!customerList.ContainsKey(customer))
                    {
                        double sum = double.Parse(quantity) * double.Parse(price);
                        string result = $"{product} - {sum:f2}";
                        customerList.Add(customer, result);
                    }
                }
                input = Console.ReadLine();
            }
            foreach (var currCustomerOrder in customerList)
            {
                string[] productAndPrice = currCustomerOrder.Value.Split(" - ").ToArray();
                Console.WriteLine($"{currCustomerOrder.Key}: {productAndPrice[0]} - {productAndPrice[1]}");
                totalIncome += double.Parse(productAndPrice[1]);
            }
            Console.WriteLine($"Total income: {totalIncome:f2}");
        }
    }
}

