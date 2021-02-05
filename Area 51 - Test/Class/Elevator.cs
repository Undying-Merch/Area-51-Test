using System;
using System.Collections.Generic;
using System.Text;

namespace Area_51___Test
{
    class Elevator
    {
        
        private int floor;
        public int Floor { get; set; }

        private int[] pickupFloor = new int[19];
        public int[] PickupFloor { get; set; } = new int[19];

        private int[] targetFloor = new int[19];
        public int[] TargetFloor { get; set; } = new int[19];

        private bool inUse;
        public bool InUse { get; set; }

        private int queue;
        public int Queue { get; set; }

        private bool isQueued;
        public bool IsQueued { get; set; }

        private int order;
        public int Order { get; set; }

        private int orderNumber;
        public int OrderNumber { get; set; }

        private bool orderCheck;
        public bool OrderCheck { get; set; }

        public int upOrDown(int x, int y, int z, bool something)
        {
            if (something == false)
            {
                if (x < y)
                {
                    x++;
                    return x;
                }
                else if (x > y)
                {
                    x--;
                    return x;
                }
                else
                {
                    return x;
                }

            }
            else if (something == true)
            {
                if (x < z)
                {
                    x++;
                    return x;
                }
                else if (x > z)
                {
                    x--;
                    return x;
                }
                else
                {
                    return x;
                }
                
            }
            else
            {
                return x;
            }

        }

        
       
    }
}
