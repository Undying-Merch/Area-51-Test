using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Area_51___Test
{
    class Control
    {
        private int isItAutomatic;
        public int IsItAutomatic { get; set; }

        private int request;
        public int Request { get; set; }

        private int certificate;
        public int Certificate { get; set; }

        private int security;
        public int Security { get; set; }

        private int personalNumber;
        public int PersonalNumber { get; set; }

        private int currentFloor;
        public int CurrentFloor { get; set; }

        private bool kill;
        public bool Kill { get; set; }

        private bool thereIsKillOrder;
        public bool ThereIsKillOrder { get; set; }

        private bool isDead;
        public bool IsDead { get; set; }

        private int floorToKill;
        public int FloorToKill { get; set; }

        private int personToKill;
        public int PersonToKill { get; set; }

        public bool intruderDetect(int x)
        {
            if (x == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool confirmedDead(bool x, int y, string a, string b)
        {
            if (x == true)
            {
                Console.WriteLine("Confirmed kill of personal number " + y);
                Console.WriteLine("With the alias " + a);
                Console.WriteLine("On " + b + ".");
                Console.WriteLine("System will now shut down.");

                return true;
            }
            else
            {
                return false;
            }
        }

        public string floorString(int x)
        {
            if (x == 0)
            {
                return "Groundfloor";
            }
            else if (x == 1)
            {
                return "B1";
            }
            else if (x == 2)
            {
                return "B2";
            }
            else if (x == 3)
            {
                return "B3";
            }
            else
            {
                return "";
            }
        }

        public int manualOrAutomatic()
        {
            string x;
            int y;
            bool isIt = false;
            Console.WriteLine("If you want the program to run automatically, please press 1");
            Console.WriteLine("If you want manual input, please press 2");
            x = Console.ReadLine();
            if (x == "1" || x == "2")
            {
                isIt = true;
            }
            while (isIt == false)
            {
                Console.WriteLine("Please input the right number.");
                x = Console.ReadLine();
                if (x == "1" || x == "2")
                {
                    isIt = true;
                }
            }
            y = Int32.Parse(x);
            return y;
        }

        public int runningProgramm(int x)
        {
            if (x == 1)
            {
                Thread.Sleep(2000);
            }
            else if (x == 2)
            {
                Console.WriteLine("Please press enter to continue");
                Console.ReadLine();
            }
            return x;
        }
    }
}
