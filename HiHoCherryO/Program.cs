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
            Console.WriteLine("Press enter to take your turn\n");

            Game game = new Game(new string[] { "Purple", "Orange", "Green", "Red" });

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