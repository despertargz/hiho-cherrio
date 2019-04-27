using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiHoCherryO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("How many players? ");
            int playerCount = int.Parse(Console.ReadLine());

            string[] possiblePlayers = new string[] { "Green", "Red", "Blue" };
            string[] players = possiblePlayers.Take(playerCount).ToArray();

            Game game = new Game(players);

            Console.WriteLine("Press enter to take your turn\n");

            while (true)
            {
                var tree = game.GetTree();

                Console.WriteLine(tree.Color + " tree's turn");
                Console.ReadLine();

                var action = game.TakeTurn();

                Console.WriteLine(">>> Got a " + action.Name + "! " + tree.Count() + " cherries left\n");

                if (tree.IsEmpty())
                {
                    Console.WriteLine(tree.Color + " tree wins!");
                    break;
                }
            }

            Console.ReadLine();
        }
    }

}