using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiHoCherryO
{
    class Tree
    {
        private int Max = 10;

        private List<Cherry> Cherries = new List<Cherry>();

        public string Color;

        public Tree(string color)
        {
            this.Color = color;

            for (int x = 0; x < this.Max; x++)
            {
                this.Cherries.Add(new Cherry() { Color = color });
            }
        }

        public bool IsEmpty()
        {
            return this.Count() == 0;
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
}
