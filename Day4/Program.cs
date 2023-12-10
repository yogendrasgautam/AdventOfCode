using System.ComponentModel.DataAnnotations;

namespace Day4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input.txt").ToList<string>();
            Part1(lines);
            Part2(lines);
        }

        private static void Part1(List<string> lines)
        {
            var total = 0;
            foreach (var line in lines)
            {
                var numbers = line.Split(':')[1].Split('|');
                var winningNumbers = numbers[0].Trim().Split(' ').Where(x => !string.IsNullOrEmpty(x));
                var numbersIHave = numbers[1].Trim().Split(' ').Where(x => !string.IsNullOrEmpty(x));

                var numberWon = winningNumbers.Intersect(numbersIHave);

                var winningPoints = numberWon.Count() == 1 ? 1 : Math.Pow(2, numberWon.Count() - 1);

                total += (int)winningPoints;
            }
            Console.WriteLine($"Part 1: {total}");
        }


        private static void Part2(List<string> lines)
        {
            var numbersWon = new List<int>();

            foreach(var line in lines)
            {
                var numbers = line.Split(':')[1].Split('|');
                var winningNumbers = numbers[0].Trim().Split(' ').Where(x => !string.IsNullOrEmpty(x));
                var numbersIHave = numbers[1].Trim().Split(' ').Where(x => !string.IsNullOrEmpty(x));

                var numberWon = winningNumbers.Intersect(numbersIHave);

                numbersWon.Add(numberWon.Count());
            }

            var noOfCards = Enumerable.Repeat(1, numbersWon.Count).ToList();

            for(int i =0; i < noOfCards.Count; i++)
            {
                for(int j =0; j < numbersWon[i]; j++)
                {
                    noOfCards[i+j+1] = noOfCards[i+j+1] + noOfCards[i];
                }
            }

            Console.WriteLine($"Part 2: {noOfCards.Sum()}");
        }
    }
}