using System;
using System.Collections.Generic;
using System.Text;

namespace Area_51___Test
{
    class Turret: Scanner
    {
        private int timeKill;
        public int TimeKill { get; set; }

        private bool kill;
        public bool Kill { get; set; }

        private bool isDead;
        public bool IsDead { get; set; }

        public int killSequence(int x, string y)
        {
            if (x == 0)
            {
                Console.WriteLine("Initializing kill sequence on " + y +"...");
                Console.WriteLine();
            }
            else if (x == 1)
            {
                Console.WriteLine("Locking on to target on " + y + "...");
                Console.WriteLine();
            }
            else if (x == 2)
            {
                Console.WriteLine("Firering at target on" + y + "...");
                Console.WriteLine();
            }
            else if (x == 3)
            {
                Console.WriteLine("Target has been confirmed dead.");
                Console.WriteLine();
            }

            x++;
            return x;
        }

        public bool isTargetdead (int x)
        {
            if (x == 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
