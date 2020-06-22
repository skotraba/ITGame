using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//PC class for the problem that will be in each room

namespace ITGame
{

    

    class PC
    {
        private string name;
        private int process;
        private double performance;
        private int startUp;

        public PC(string name)
        {
            this.name = name;
        }

        public PC(string name, int process, double performance, int startUp)
        {
            this.name = name;
            this.process = process;
            this.performance = performance;
            this.startUp = startUp;
        }

        public string getPCName()
        {
            return this.name;
        }

        //Possibly need these for rebooting and troubleshooting
        public void setProcess()
        {
            this.process = 0;
        }

        public void setPerformance()
        {
            this.performance = 10.0;
        }

        public void setStartUp()
        {
            this.startUp = 0;
        }

        public bool initPCLoopEast()
        {
            Console.WriteLine("You are looking at Barb's computer.  \nShe's complaining that it won't turn on.  \nYou look at the computer and the screen is black");
            Console.WriteLine("You need to troubleshoot the computer to leave the room, what would you like to do?\n");
            Console.WriteLine("1. Turn the computer on  \n2. Check if it's plugged in \n3. Turn the computer on and enter BIOS \n4. Smell the Computer \n5. Hit the Computer \n6. Leave Computer");
            
            
            bool PCPower = false;
            while (!PCPower)
            {
                String userChoice = Console.ReadLine();
                switch (userChoice)
                {
                    case "1":
                        Console.WriteLine("Nothing happens, it's like there's no power or something.");
                        break;
                    case "2":
                        Console.WriteLine("The computer was not plugged in. Do you want to plug it in? y/n");
                        string choice = Console.ReadLine();
                        while (!choice.Equals("y"))
                        {
                            Console.WriteLine("Okay, but the computer should probably be plugged in...");
                            Console.WriteLine("I'll do it for you. Jeez.");
                            break;
                        }
                        Console.WriteLine("The computer is plugged in. You should try turning it on");
                        PCPower = true;
                        break;
                    case "3":
                        Console.WriteLine("The computer does not turn on. Try something else.");
                        break;
                    case "4":
                        Console.WriteLine("It smells like there is not power");
                        break;
                    case "5":
                        Console.WriteLine("Don't be stupid");
                        break;
                    case "6":
                        return false;
                    default:
                        Console.WriteLine("The computer is still broken");
                        break;
                }
            }
            Console.WriteLine("Turn the computer on by typing 'power'");
            string pchoice = Console.ReadLine();
            if (pchoice.Equals("power"))
            {
                Console.WriteLine("Looks like the pc is turned on and good to go. Barb is an idiot. Let's move on.");
            }
            else
            {
                Console.WriteLine("Alright, I'll turn it on for you.  Looks like the computer is fixed. Let's move on.");
            }
            return true; 

            
        }

        public bool initPCRoomWest()
        {
            Console.WriteLine("You approach Carol's computer and she says it is running slow lately.\n");
            Console.WriteLine("You need to troubleshoot the computer before you can leave the building.");
            Console.WriteLine("You can:\n1.Restart the computer \n2.Check Task Manager \n3.Pull the plug \n4.Leave");

            bool isFixed = false;
            while (!isFixed)
            {
                string playerChoice = Console.ReadLine();
                switch (playerChoice)
                {
                    case "1":
                        Console.WriteLine("The computer restarts.");
                        this.process = 0;
                        break;
                    case "2":
                        this.taskChecker();
                        break;
                    case "3":
                        break;
                    case "4":
                        return false;
                    default:
                        Console.WriteLine("Please try something else");
                        break;
                }
            }
            Console.WriteLine("The computer seems to be running faster. Good job.  Leave this room.");
            return true;
        }

        public void initPCRoomNorth()
        {
            Console.WriteLine("You intiate the north room PC problem");
        }

        public void taskChecker()
        {
            

            Console.WriteLine("The task manager loads. What do you want to check?\n");
            Console.WriteLine("1.Process \n2.Performance \n3.Start Up \n4.Quit \n");
            

            bool isChecking = false;

            while (!isChecking)
            {
                string playerChoice = Console.ReadLine();
                switch (playerChoice)
                {
                    case "1":
                        Console.WriteLine($"You check the processes running and see {this.process} chrome tabs are open.\n");
                        break;
                    case "2":
                        Console.WriteLine($"The CPU performance is running at {this.performance}%\n");
                        break;
                    case "3":
                        Console.WriteLine($"There are {this.performance} programs enabled on start up");
                        break;
                    case "4":
                        Console.WriteLine("You quit the task manager");
                        isChecking = true;
                        break;
                    default:
                        break;
                }
            }

           
        }
    }
}
