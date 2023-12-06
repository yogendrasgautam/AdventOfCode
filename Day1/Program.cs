using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace Day1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input.txt").ToList<string>();
            var l = lines.Select(a => ReplaceDigitTexts(a)).Select(a => Regex.Matches(a, @"\d").Select(m => int.Parse(m.Value)).ToArray());
            // add the first and last number to the sum

            var sum = l.Select(a => $"{a[0]}{a[a.Length - 1]}").Select(a => int.Parse(a)).Sum();

            Console.WriteLine(sum);
        }

        // create extension method for string to replace all occurrences of a string with another string
        private static string ReplaceDigitTexts(string str)
        {
            var keyValuePairs = new Dictionary<string, string>
            {
                { "one", "1" },
                { "two", "2" },
                { "three", "3" },
                { "four", "4" },
                { "five", "5" },
                { "six", "6" },
                { "seven", "7" },
                { "eight", "8" },
                { "nine", "9" },
                { "oneight", "18" },
                { "twone", "21" },
                { "threeight", "38" },
                { "fiveight", "58" },
                { "sevenine", "79" },
                { "eightwo", "82" },
                { "eighthree", "83" },
                { "nineight", "98" },
            };

            foreach (var item in keyValuePairs)
            {
                str = str.Replace(item.Key, item.Value);
            }

            return str;
        }
    }
}