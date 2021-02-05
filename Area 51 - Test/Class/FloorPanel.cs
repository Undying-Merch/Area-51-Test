using System;
using System.Collections.Generic;
using System.Text;

namespace Area_51___Test
{
    class FloorPanel: Scanner
    {
        private bool isAllowed;
        public bool IsAllowed { get; set; }

        private int currentFloor;
        public int CurrentFloor { get; set; }

        private int targetFloor;
        public int TargetFloor { get; set; }

        public bool accessAllowed(int x, int y)
        {
            if (x >= y)
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
