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

    class Game
    {
        private int Turn = 0;

        private Spinner Spinner = new Spinner();

        public Tree[] Trees;

        public Basket Basket = new Basket();

        public Game()
        {
            Trees = new Tree[]
            {
                new Tree("Red"),
                new Tree("Blue"),
                new Tree("Green")
            };
        }

        public Tree GetTree()
        {
            int index = this.Turn % Trees.Count();
            return Trees[index];
        }

        public Action TakeTurn()
        {
            var tree = GetTree();

            var action = this.Spinner.Spin();

            if (action.Value > 0)
            {
                var cherries = tree.Remove(action.Value);
                this.Basket.Add(cherries);
            }
            else
            {
                var cherries = this.Basket.Remove(tree.Color, Math.Abs(action.Value));
                tree.Add(cherries);
            }

            this.Turn++;
            return action;
        }
    }

    class Tree
    {
        private int Max = 10;

        private List<Cherry> Cherries = new List<Cherry>();

        public string Color;

        public Tree(string color)
        {
            this.Color = color;

            for (int x=0; x < this.Max; x++)
            {
                this.Cherries.Add(new Cherry() { Color = color });
            }
        }

        public int Count()
        {
            return this.Cherries.Count;
        }

        public Cherry[] Remove(int number)
        {
            List<Cherry> removed = new List<Cherry>();

            for (int x = 0; x < number; x++)
            {
                if (this.Cherries.Count() > 0)
                {
                    this.Cherries.RemoveAt(0);
                    removed.Add(new Cherry() { Color = this.Color });
                }
            }

            return removed.ToArray();
        }

        public void Add(Cherry[] cherries)
        {
            this.Cherries.AddRange(cherries);
        }
    }

    class Cherry
    {
        public string Color;
    }

    class Basket
    {
        private List<Cherry> Cherries = new List<Cherry>();

        public void Add(Cherry[] cherries)
        {
            this.Cherries.AddRange(cherries);
        }

        public Cherry[] Remove(string color, int number)
        {
            List<Cherry> removed = new List<Cherry>();
            for (int x = 0; x < number; x++)
            {
                var cherry = this.Cherries.FirstOrDefault(o => o.Color == color);
                if (cherry != null)
                {
                    this.Cherries.Remove(cherry);
                    removed.Add(cherry);
                }
            }

            return removed.ToArray();
        }

        public void PrintContents()
        {
            Console.WriteLine("\nBasket:");
            foreach (var color in this.Cherries.GroupBy(o => o.Color))
            {
                Console.WriteLine(color.Key + ": " + color.Count());
            }
            Console.WriteLine();
        }
    }

    class Spinner
    {
        private Random Random = new Random();

        private Action[] Actions = new Action[]
        {
            new Action() { Name = "Dog", Value = -2 },
            new Action() { Name = "Bird", Value = -2 },
            new Action() { Name = "Basket", Value = -10 },
            new Action() { Name = "One", Value = 1 },
            new Action() { Name = "Two", Value = 2 },
            new Action() { Name = "Three", Value = 3 },
            new Action() { Name = "Four", Value = 4 }
        };

        public Action Spin()
        {
            int spinNumber = Random.Next(7);
            return this.Actions[spinNumber];
        }
    }

    class Action
    {
        public string Name;

        public int Value;
    }
}