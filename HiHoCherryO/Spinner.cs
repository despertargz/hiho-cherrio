using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiHoCherryO
{
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
            int spinNumber = Random.Next(this.Actions.Length);
            return this.Actions[spinNumber];
        }
    }
}
