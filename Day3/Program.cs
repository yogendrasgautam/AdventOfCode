
using System.Text.RegularExpressions;

namespace Day3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input.txt");
            Part1(lines);
            Part2(lines);
        }

        private static void Part1(string[] lines)
        {
            var symbolIndex = new List<string>();
            int total = 0;
            var numberIndexes = new List<KeyValuePair<int, string[]>>();
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                //Console.WriteLine(line);
                for (int j = 0; j < line.Length; j++)
                {
                    // find the index of character in line which is not number, alphanumeric or dot
                    if (!char.IsNumber(line[j]) && !char.IsLetter(line[j]) && line[j] != '.')
                    {
                        // add the index of character to the array
                        symbolIndex.Add(i + "," + j);
                    }

                    if (char.IsNumber(line[j]))
                    {

                        var numberIndex = new List<string>();
                        var number = "";
                        var startIndex = j;
                        while (j < line.Length && char.IsNumber(line[j]))
                        {
                            number = number + "" + line[j];
                            j++;
                        }
                        var endIndex = j - 1;
                        j = j - 1;

                        numberIndex.Add(i + "," + (startIndex - 1));
                        numberIndex.Add(i + "," + (endIndex + 1));
                        numberIndex.Add(i - 1 + "," + (startIndex - 1));
                        numberIndex.Add(i - 1 + "," + startIndex);
                        numberIndex.Add(i - 1 + "," + (endIndex + 1));
                        var index = startIndex + 1;
                        while (index <= endIndex)
                        {
                            numberIndex.Add(i - 1 + "," + index);
                            numberIndex.Add(i + 1 + "," + index);
                            index++;
                        }
                        numberIndex.Add(i + 1 + "," + (startIndex - 1));
                        numberIndex.Add(i + 1 + "," + startIndex);
                        numberIndex.Add(i + 1 + "," + (endIndex + 1));

                        numberIndexes.Add(new KeyValuePair<int, string[]>(int.Parse(number), numberIndex.ToArray()));
                    }
                }
            }
            // check if any numberIndex is in symbolIndexes using linq
            foreach (var item in numberIndexes)
            {
                var isNumberIndexInSymbolIndexes = item.Value.Any(a => symbolIndex.Contains(a));
                if (isNumberIndexInSymbolIndexes)
                {
                    total += item.Key;
                }
            }

            Console.WriteLine($"Part 1 Total: {total}");
        }

        private static void Part2(string[] lines)
        {
            // create dynamic array
            var symbolIndex = new List<string>();

            var symbolIndexes = new Dictionary<string, string[]>();
            int total = 0;
            var numberIndexes = new List<KeyValuePair<int, string[]>>();
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                //Console.WriteLine(line);
                for (int j = 0; j < line.Length; j++)
                {
                    // find the index of character in line which is not number, alphanumeric or dot
                    if (line[j] == '*')
                    {
                        // add the index of character to the array
                        symbolIndex.Add(i + "," + j);

                    }

                    if (char.IsNumber(line[j]))
                    {

                        var numberIndex = new List<string>();
                        var number = "";
                        var startIndex = j;
                        while (j < line.Length && char.IsNumber(line[j]))
                        {
                            number = number + "" + line[j];
                            j++;
                        }
                        var endIndex = j - 1;
                        j = j - 1;

                        numberIndex.Add(i + "," + (startIndex - 1));
                        numberIndex.Add(i + "," + (endIndex + 1));
                        numberIndex.Add(i - 1 + "," + (startIndex - 1));
                        numberIndex.Add(i - 1 + "," + startIndex);
                        numberIndex.Add(i - 1 + "," + (endIndex + 1));
                        var index = startIndex + 1;
                        while (index <= endIndex)
                        {
                            numberIndex.Add(i - 1 + "," + index);
                            numberIndex.Add(i + 1 + "," + index);
                            index++;
                        }
                        numberIndex.Add(i + 1 + "," + (startIndex - 1));
                        numberIndex.Add(i + 1 + "," + startIndex);
                        numberIndex.Add(i + 1 + "," + (endIndex + 1));

                        numberIndexes.Add(new KeyValuePair<int, string[]>(int.Parse(number), numberIndex.ToArray()));
                    }
                }
            }
            // check if any numberIndex is in symbolIndexes using linq

            foreach (var item in symbolIndex)
            {
                var numbers = numberIndexes.Where(a => a.Value.Contains(item)).Select(a => a.Key);

                // find the product of numbers
                if (numbers.Count() > 1)
                {
                    var product = numbers.Aggregate((a, b) => a * b);
                    total += product;
                }
            }
            Console.WriteLine($"Part 2 Total: {total}");
        }
    }
}