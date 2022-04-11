using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monty_Hall_Problem
{
    internal class Door
    {
      
        private bool car = false;
        public bool Car { get { return car; }}

        public Door(bool car)
        {
            this.car = car;      
        }
        static public Door[] InitialiseDoorsFalse(Door[] doors)
        {
            for (int i = 0; i < 3; i++)
            {
                doors[i] = new Door(false);
            }
            return doors;
        }
        
    }
}
