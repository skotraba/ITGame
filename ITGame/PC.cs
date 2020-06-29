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

        public PC(string name, int process, int startUp)
        {
            this.name = name;
            this.process = process;
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

        //East Room Computer Power Problem
        public bool initPCLoopEast()
        {
            Console.WriteLine("You are looking at Barb's computer.  \nShe's complaining that it won't turn on.  \nYou look at the computer and the screen is black");
            Console.WriteLine("You need to troubleshoot the computer to leave the room\n");
            bool PCPower = false;
            while (!PCPower)
            {
                printMenuEast();
                String userChoice = Console.ReadLine();
                switch (userChoice)
                {
                    case "1":
                        Console.WriteLine("Nothing happens, it's like there's no power or something.\n");
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

        //West Room PC Problem. Slow Computer
        public bool initPCRoomWest()
        {

            bool isFixed = true;
            
          
            
            while (!isFixed)
            {
                double currentCPU = checkPerform();
                if (currentCPU <= 10)
                {
                    isFixed = true;
                }
                else
                {
                    isFixed = false;
                    Console.WriteLine("You approach Carol's computer and she says it is running slow lately.\n");
                    Console.WriteLine("You need to troubleshoot the computer before you can leave the building.\n");
                    printMenuWest();
                }
                string playerChoice = Console.ReadLine();
                switch (playerChoice)
                {
                    case "1":
                        Console.WriteLine("The computer restarts.\n");
                        this.process = 0;
                        printMenuWest();
                        break;
                    case "2":
                        this.taskChecker();
                        printMenuWest();
                        break;
                    case "3":
                        Console.WriteLine("Great. Now I'll plug it in and you have to wait for it to restart.\n");
                        for(int i=1; i < 6; i++)
                        {
                            System.Threading.Thread.Sleep(1000);
                            Console.WriteLine(i);
                            System.Threading.Thread.Sleep(1000);
                        }
                        System.Threading.Thread.Sleep(2000);
                        Console.WriteLine("The Computer restarted");
                        this.process = 0;
                        this.checkPerform();
                        printMenuWest();
                        break;
                    case "4":
                        return false;
                    //Debug only
                    case "fix":
                        this.process = 10;
                        Console.WriteLine($"Process is {this.process}");
                        return true;
                    default:
                        Console.WriteLine("Please try something else");
                        printMenuWest();
                        break;
                }
            }
            Console.WriteLine("The computer seems to be running faster. Good job.  Leave this room.\n");
            return true;
        }

        public void initPCRoomNorth()
        {
            Console.WriteLine("You intiate the north room PC problem");
        }

        //Task Manager
        public void taskChecker()
        {
            Console.WriteLine("The task manager loads. What do you want to check?\n");
            printTaskMenu();
            bool isChecking = true;

            while (isChecking)
            {
                string playerChoice = Console.ReadLine();
                switch (playerChoice)
                {
                    case "1":
                        Console.WriteLine($"You check the processes running and see {this.process} chrome tabs are open.\n");
                        printTaskMenu();
                        break;
                    case "2":
                        Console.WriteLine($"The CPU performance is running at {checkPerform()}%\n");
                        printTaskMenu();
                        break;
                    case "3":
                        Console.WriteLine($"There are {this.startUp} programs enabled on start up\n");

                        if(this.startUp > 0)
                        {
                            Console.WriteLine("Do you want to disable start up processes?");
                            string choice = Console.ReadLine();
                            if (choice == "y")
                            {
                                Console.WriteLine("You cleared the start up apps. Good job.");
                                this.startUp = 0;
                            }
                            else if (choice == "n")
                            {
                                Console.WriteLine("You might want to try clearing the start up apps...");
                               
                            }
                            else
                            {
                                Console.WriteLine("Please enter a 'y' or 'n' \n");
                            }
                        }
                        
                        printTaskMenu();
                        break;
                    case "4":
                        Console.WriteLine("You quit the task manager");
                        isChecking = false;
                        break;
                    case "5":
                        Console.WriteLine($"The computer CPU is running at {this.process}%");
                        if (this.process <= 10)
                        {
                            Console.WriteLine("Good job.  The computer seems to be running more effectively.  Let's leave this room.");
                            isChecking = false;
                            
                        }
                        else
                        {
                            Console.WriteLine("You should try so more troubleshooting things...It's still real slow. ");
                            printTaskMenu();
                        }
                        break;
                    default:
                        break;
                }
            }
            
        }

        public void printMenuWest()
        {
            
            Console.WriteLine("You can:\n1.Restart the computer \n2.Check Task Manager \n3.Pull the plug \n4.Leave\n");
        }

        public void printMenuEast()
        {

            Console.WriteLine("What would you like to do?\n");
            Console.WriteLine("1. Turn the computer on  \n2. Check if it's plugged in \n3. Turn the computer on and enter BIOS \n4. Smell the Computer \n5. Hit the Computer \n6. Leave Computer\n");

        }

        public void printTaskMenu()
        {

            Console.WriteLine("1.Process \n2.Performance \n3.Start Up \n4.Quit \n5.Check overall speed \n");
        }

        public double checkPerform()
        {
            return this.performance = (this.process + this.startUp) + 10;
        }
    }
}
