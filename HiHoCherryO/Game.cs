using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiHoCherryO
{
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

}
