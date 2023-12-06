using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    internal class Game
    {
        private Game()
        {
        }
        public int Id { get; private set; }
        public List<Set> Sets { get; private set; } = new List<Set>();
        public bool IsPossibleGame { get; private set; } = true;
        public int PowerOfCubes { get; set; }

        public static Game CreateGame(string idString, string setString)
        {
            var game = new Game
            {
                Id = int.Parse(idString.Split(' ')[1])
            };

            foreach (var set in setString.Split(';'))
            {
                var createdSet = Set.CreateSet(set);
                game.Sets.Add(createdSet);

                if (!createdSet.IsValidSet)
                {
                    game.IsPossibleGame = false;
                }
            }

            // get max value for each key in the dictionary
            var maxRed = game.Sets.Select(a => a.Cubes.ContainsKey("red") ? a.Cubes["red"] : 0).Max();
            var maxGreen = game.Sets.Select(a => a.Cubes.ContainsKey("green") ? a.Cubes["green"] : 0).Max();
            var maxBlue = game.Sets.Select(a => a.Cubes.ContainsKey("blue") ? a.Cubes["blue"] : 0).Max();

            game.PowerOfCubes = (maxRed == 0 ? 1 : maxRed) * (maxGreen == 0 ? 1 : maxGreen) * (maxBlue == 0 ? 1 : maxBlue);

            return game;
        }
    }

    internal class Set
    {
        private Set()
        {
        }
        public Dictionary<string, int> Cubes { get; private set; } = new Dictionary<string, int>();

        public bool IsValidSet { get; set; }
        public static Set CreateSet(string setString)
        {
            var set = new Set
            {
                Cubes = setString.Split(',').Select(a => a.Trim().Split(' ')).ToDictionary(a => a[1], a => int.Parse(a[0]))
            };

            set.IsValidSet = set.RecogniseValidSet();

            return set;
        }

        private bool RecogniseValidSet()
        {
            var isValid = true;
            var red = Cubes.ContainsKey("red") ? Cubes["red"] : 0;
            var green = Cubes.ContainsKey("green") ? Cubes["green"] : 0;
            var blue = Cubes.ContainsKey("blue") ? Cubes["blue"] : 0;

            if (red > 12 || green > 13 || blue > 14)
            {
                isValid = false;
            }

            return isValid;
        }

        // create hashset to store red, green and blue values
    }
}
