using System;

namespace Monty_Hall_Problem 
{
    internal class Program
    {
        public static bool stayDoor = false;
        public static decimal carCountStay = 0;
        public static decimal carCountSwitch = 0;
        // need a way to store the wins and not wins
        // therefore wins (if they pick the car) will be 1 and loses (if they pick the goat) would be 0

        public static int[,] allResults = new int[1000,2];




        public static void Main(string[] args)
        {
            Console.SetWindowSize(74,30);
            PrintHeader();
            RepeatThousandTimes(true,0);
            RepeatThousandTimes(false,0);
            PrintResults(1);

            RepeatThousandTimes(true, 1);
            RepeatThousandTimes(false, 1);
            PrintResults(2);

            RepeatThousandTimes(true, 2);
            RepeatThousandTimes(false, 2);
            PrintResults(3);

            Console.WriteLine("As you can see the percentage for switching is higher for all three strategies therefore switching would give you the higher chance of getting the car!");
            Console.ReadKey();
        }
        static public void PlaceCarInArray(int strategy, int i, bool stayDoor)
        {
            
            // makes door array and creates 3 doors and puts them inside
            Door[] doors = new Door[3];
            doors = Door.InitialiseDoorsFalse(doors);

            // this random number will be the position of the car in the array
            Random random = new Random();
            int randomNumber = random.Next(1, 4);
        
            doors[randomNumber - 1] = new Door(true);
            int montyPick = 0;
            // this is the switch door method
            if (stayDoor == false)
            {
                bool result = Strategies.SwitchDoor(doors, strategy, MontyPickRandomGoat(doors, montyPick));
                if (result)
                {
                    allResults[i,0] = 1;
                    carCountSwitch++; 
                }
                else
                    allResults[i,0] = 0;
                
            }
            else 
            {
                bool result = Strategies.KeepOriginalDoor(doors, strategy);
                if (result)
                {
                    allResults[i,1] = 1;
                    carCountStay++;
                }
                else
                    allResults[i,1] = 0;
            }    
        }
        
        static public int MontyPickRandomGoat(Door[] doors, int montyPick)
        {           
            // create a loop which creates a random number and picks the first random position in the array which is a goat
            bool whileLoop = true;
            while (whileLoop)
            {
                try
                {
                    Random random = new Random();
                    int count = random.Next(1, 4);
                    // this stores monty's selection of the random doors position in array which is goat.
                    if (doors[count - 1].Car == false)
                    {
                        montyPick = count - 1;
                        whileLoop = false;
                    }
                        
                }
                catch
                {

                }
            }
            return montyPick;
        }        
        static public void PrintHeader()
        {
            Console.WriteLine("█▀▄▀█ █▀█ █▄░█ ▀█▀ █▄█   █░█ ▄▀█ █░░ █░░   █▀█ █▀█ █▀█ █▄▄ █░░ █▀▀ █▀▄▀█");
            Console.WriteLine("█░▀░█ █▄█ █░▀█ ░█░ ░█░   █▀█ █▀█ █▄▄ █▄▄   █▀▀ █▀▄ █▄█ █▄█ █▄▄ ██▄ █░▀░█");
            Console.WriteLine("         Proving the monty hall problem with different strategies");
            Console.WriteLine(" ");
            Console.WriteLine("--------------------------------------------------------------------------");
           
           
        }
        static public void RepeatThousandTimes(bool a,int strategy)
        {
            for (int i = 0; i < 1000; i++)
            {
                PlaceCarInArray(strategy,i,a);
            }
        }
        static public void PrintResults(int q)
        {
            Console.WriteLine("             Strategy "+q+" : Picking door "+q+" (switching and staying)");
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("\n\n                      0 = Goat      1 = Car");
            Console.WriteLine(" ");
            Console.WriteLine("                 Game         Stay        Switch");
            Console.WriteLine("                 ________________________________");



            for (int i = 0; i < 1000; i++)
            {
                Console.Write("                  " + i + "       |    ");
                for (int j = 0; j < 2; j++)
                {

                    Console.Write(allResults[i,j]);
                        
                    Console.Write("    |      ");

                   
                }
                Console.WriteLine();
                
            }

            
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("                Percentage of Car for switch : " + (carCountSwitch/1000)*100 + "%");
            Console.WriteLine("                Percentage of Car for stay   : " + (carCountStay / 1000) * 100 + "%");
            Console.WriteLine("--------------------------------------------------------------------------");
            carCountStay = 0;
            carCountSwitch = 0;
        }
        
    }
}


