using System;
using System.Threading;

namespace Area_51___Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //Random number generator
            int randNumb(int x)
            {
                int numb;
                var rand = new Random();
                numb = rand.Next(x);
                return numb;
            } 
            string[] names = new string[] { "James", "Colling", "Will", "Michelle", "Justin", "Ben", "Bruce", "Camille", "Hans", "Gordon", "Jessie", "Brick", "Tina", "Rowan", "Alan", "Pierce", "Chloe", "Sungjin Woo", "Sinbaad", "Lucifer" };

            //Creating all the objects from classes
            Elevator elevator = new Elevator();
            elevator.Floor = 0;
            elevator.Queue = 0;
            elevator.OrderCheck = false;
            for (int i = 0; i < 19; i++)
            {
                elevator.TargetFloor[i] = 5;
            }
            Panel panel = new Panel();
            Control control = new Control();
            control.ThereIsKillOrder = false;
            control.PersonalNumber = 0;
            FloorPanel[] floorPanels = new FloorPanel[4];
            for (int i = 0; i < 4; i++)
            {
                floorPanels[i] = new FloorPanel();
            }
            Scanner[] floorScanner = new Scanner[4];
            for (int i = 0; i < 4; i++)
            {
                floorScanner[i] = new Scanner();
            }
            Turret[] floorTurret = new Turret[4];
            for (int i = 0; i < 4; i++)
            {
                floorTurret[i] = new Turret();
            }
            Personal[] personalPpl = new Personal[19];
            for (int i = 0; i < 19; i++)
            {
                personalPpl[i] = new Personal();
                personalPpl[i].Spawn = randNumb(4);
                personalPpl[i].Certificate = randNumb(6);
                personalPpl[i].TargetFloor = randNumb(4);
                while (personalPpl[i].Spawn == personalPpl[i].TargetFloor)
                {
                    personalPpl[i].TargetFloor = randNumb(4);
                }
                personalPpl[i].Alive = true;
                personalPpl[i].Spawned = false;
                personalPpl[i].Name = names[i];
                personalPpl[i].SpawnTime = randNumb(6);

            }

            Console.WriteLine("Initializing security program...");

            control.IsItAutomatic = control.manualOrAutomatic();

            while (control.IsDead == false)
            {
                //Tjekker om personalet er spawnet, hvis timeren for nyt spawn er i 0 vil den spawne et nyt personale.
                if (personalPpl[control.PersonalNumber].Spawned == false)
                {
                    //Sætter at peronalet er blevet spawnet og begynder derefter at sende personalets info til terminaler og control.
                    personalPpl[control.PersonalNumber].Spawned = true;
                    control.CurrentFloor = personalPpl[control.PersonalNumber].Spawn;
                    Console.WriteLine("Personal number " + (control.PersonalNumber + 1) + " has spawned on " + control.floorString(personalPpl[control.PersonalNumber].Spawn));
                    control.IsItAutomatic = control.runningProgramm(control.IsItAutomatic);
                    Console.WriteLine("Scanning card, please wait.");
                    floorScanner[control.CurrentFloor].certificate = personalPpl[control.PersonalNumber].Certificate;
                    control.Certificate = floorScanner[personalPpl[control.PersonalNumber].Spawn].certificate;
                    floorPanels[control.CurrentFloor].CurrentFloor = personalPpl[control.PersonalNumber].Spawn;
                    floorPanels[control.CurrentFloor].TargetFloor = personalPpl[control.PersonalNumber].TargetFloor;
                    Thread.Sleep(1500);
                    Console.WriteLine("Name: " + personalPpl[control.PersonalNumber].Name);
                    Thread.Sleep(1500);
                    Console.WriteLine("Requesting access to " + control.floorString(personalPpl[control.PersonalNumber].TargetFloor));
                    Thread.Sleep(1500);
                    Console.WriteLine("Security clearance is: " + personalPpl[control.PersonalNumber].Certificate);
                    Thread.Sleep(1500);
                    //Tjekker om personalet har sikkerhed til det floor de gerne vil til.
                    floorPanels[control.CurrentFloor].IsAllowed = floorPanels[control.CurrentFloor].accessAllowed(control.Certificate, floorPanels[control.CurrentFloor].TargetFloor);

                    //Hvis de har bliver det smidt i elevator køen.
                    if (floorPanels[control.CurrentFloor].IsAllowed == true)
                    {
                        Console.WriteLine("Request has been accepted. The elevator will be with you as fast as possible");
                        control.Request = floorPanels[control.CurrentFloor].TargetFloor;
                        elevator.PickupFloor[control.PersonalNumber] = floorPanels[control.CurrentFloor].CurrentFloor;
                        elevator.TargetFloor[control.PersonalNumber] = control.Request;
                        Console.WriteLine();
                    }
                    //Hvis de ikke har tjekker den nu om det er uvelkommende folk eller bare for lav sikkerhed.
                    else if (floorPanels[control.CurrentFloor].IsAllowed == false)
                    {
                        control.Kill = control.intruderDetect(control.Certificate);
                        //Hvis det er uvelkommende begynder den kill sekvensen.
                        if (control.Kill == true)
                        {
                            //Tjekker om der allerede er en kill sekvens igang.
                            if (control.ThereIsKillOrder == true)
                            {
                                Console.WriteLine("Intruder detected, will now commence kill sequence.");
                                Console.WriteLine();
                            }
                            else
                            {
                                Console.WriteLine("Intruder detected, will now commence kill sequence.");
                                Console.WriteLine();
                                control.ThereIsKillOrder = true;
                                control.FloorToKill = control.CurrentFloor;
                                control.PersonToKill = control.PersonalNumber;
                                floorTurret[control.FloorToKill].Kill = control.Kill;
                            }
                        }
                        //Hvis de har for lav sikkerhed, sender programmet dem bare væk.
                        else
                        {
                            Console.WriteLine("Access has been denied, due to low security certificate. Please contact your current administrator.");
                            Console.WriteLine();
                        }
                    }
                    
                }
                control.IsItAutomatic = control.runningProgramm(control.IsItAutomatic);
                //Kører listen igennem af elevator requests, hvis der er en under 5 vil den automatisk gå til den.
                if (elevator.OrderCheck == false)
                {
                    for (int i = 0; i < 19; i++)
                    {
                        if (elevator.TargetFloor[i] < 5)
                        {
                            elevator.Queue = i;
                            elevator.OrderCheck = true;
                            i = 19;

                        }
                    }
                }
                //Tjekker om der er en odre fra køen, hvis der er bevæger elevatoren sig.
                if (elevator.OrderCheck == true)
                {
                    elevator.Floor = elevator.upOrDown(elevator.Floor, elevator.PickupFloor[elevator.Queue], elevator.TargetFloor[elevator.Queue], elevator.InUse);
                    Console.WriteLine("Elevator has reached: " + control.floorString(elevator.Floor));
                    Console.WriteLine();
                }
                //Tjekker om der skal samles en person op i elevatoren.
                if (elevator.Floor == elevator.PickupFloor[elevator.Queue] && elevator.OrderCheck == true)
                {
                    elevator.InUse = true;
                    Console.WriteLine("Picking up " + personalPpl[elevator.Queue].Name + " from " + control.floorString(elevator.Floor));
                    Console.WriteLine();
                }
                //Tjekker om der er en person som skal sættes af elevatoren.
                else if (elevator.Floor == elevator.TargetFloor[elevator.Queue] && elevator.InUse == true)
                {
                    elevator.InUse = false;
                    elevator.TargetFloor[elevator.Queue] = 5;
                    elevator.OrderCheck = false;
                    Console.WriteLine("Dropping of " + personalPpl[elevator.Queue].Name + " on " + control.floorString(elevator.Floor));
                    Console.WriteLine();
                }

                if (control.ThereIsKillOrder == true)
                {
                    floorTurret[control.FloorToKill].TimeKill = floorTurret[control.FloorToKill].killSequence(floorTurret[control.FloorToKill].TimeKill, control.floorString(control.FloorToKill));
                    floorTurret[control.FloorToKill].IsDead = floorTurret[control.FloorToKill].isTargetdead(floorTurret[control.FloorToKill].TimeKill);
                    control.IsDead = control.confirmedDead(floorTurret[control.FloorToKill].IsDead, control.PersonToKill, personalPpl[control.PersonToKill].Name, control.floorString(control.FloorToKill));
                }
                
                //Tjekker om spawntime er null, hvis den er spawner den næste person.
                if (personalPpl[control.PersonalNumber].SpawnTime == 0)
                {
                    control.PersonalNumber++;
                }
                //Hvis spawntime ikke er nul, tæller den ned.
                else
                {
                    personalPpl[control.PersonalNumber].SpawnTime--;
                }

                control.IsItAutomatic = control.runningProgramm(control.IsItAutomatic);
                
            }
        }
    }
}
