using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monty_Hall_Problem
{
    internal static class Strategies 
    {    
        public static bool KeepOriginalDoor(Door[] doors, int strategy)
        {
            // keep the door the same as originally picked and return if the player has won or not
            if (doors[strategy].Car == true)
                return true;
            else
                return false;
        }
        public static bool SwitchDoor(Door[] doors, int strategy, int montyPick)
        {
            // switch to the other door 
            int count = 0;
            for (int i = 0; i < doors.Length; i++)
            {
                if ((doors[strategy] != doors[i]) && (doors[montyPick] != doors[i]))
                    count = i;
            }

            if (doors[count].Car)
                return true;
            else
                return false;
        }
    }
}
