using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiHoCherryO
{
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
}
