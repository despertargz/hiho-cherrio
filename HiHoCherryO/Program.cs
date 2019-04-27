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
            Game game = new Game();

            while (true)
            {
                var tree = game.GetTree();

                Console.WriteLine(tree.Color + " tree's turn...");
                Console.ReadLine();

                var action = game.TakeTurn();

                Console.WriteLine(tree.Color + " got a " + action.Name + "! It has " + tree.Count() + " cherries left\n");

                if (tree.Count() == 0)
                {
                    Console.WriteLine(tree.Color + " tree wins!");
                    break;
                }
            }

            Console.ReadLine();
        }
    }

}