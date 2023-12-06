using System.ComponentModel.DataAnnotations;

namespace Day2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input.txt").ToList<string>();
            // seperate "Game 1: 4 blue; 1 green, 2 red; 4 blue, 1 green, 6 red" into "Game 1" and "4 blue; 1 green, 2 red; 4 blue, 1 green, 6 red"

            var game = lines.Select(a => Game.CreateGame(a.Split(':')[0], a.Split(':')[1]));
            // Part 1
            //var total = game.Where(a => a.IsPossibleGame).Sum(a => a.Id);

            // Part 2

            var total = game.Sum(a => a.PowerOfCubes);
            Console.WriteLine(total);
        }
    }
}