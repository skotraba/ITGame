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
        private string processName;
        private double performance;
        private int startUp;
        private bool VSCode;
        private bool typeScript;
        private bool npm;

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

        public PC(string name, int process, string processName, int startUp, bool VSCode, bool typeScript, bool npm)
        {
            this.name = name;
            this.process = process;
            this.startUp = startUp;
            this.processName = processName;
            this.VSCode = VSCode;
            this.typeScript = typeScript;
            this.npm = npm;

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
                    case "fix":
                        return true;
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
                Console.WriteLine("Alright, I'll turn it on for you.  Looks like the computer is fixed. Let's move on. \n");
            }
            return true; 

            
        }

        //West Room PC Problem. Slow Computer
        public bool initPCRoomWest()
        {
            Console.WriteLine("You approach Carol's computer and she says it is running slow lately.\n");
            Console.WriteLine("You need to troubleshoot the computer before you can leave the building.\n");
            printMenuWest();

            bool isFixed = false;
            
            while (!isFixed)
            {
             
                string playerChoice = Console.ReadLine();
                switch (playerChoice)
                {
                    case "1":
                        Console.WriteLine("The computer restarts.\n");
                        this.process = 10;
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
                        this.process = 10;
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
                    case "5":
                        Console.WriteLine($"The computer CPU is running at {this.checkPerform()}%");
                        if (this.process <= 20)
                        {
                            Console.WriteLine("Good job.  The computer seems to be running more effectively.  Let's leave this room.");
                            isFixed = true;

                        }
                        else
                        {
                            Console.WriteLine("You should try so more troubleshooting things...It's still real slow. ");
                            printMenuWest();
                        }
                        break;
                    default:
                        Console.WriteLine("Please try something else");
                        printMenuWest();
                        break;
                }
               
            }
            double currentCPU = checkPerform();
            if (currentCPU <= 20)
            {
                return true;
            }
            else
            {
                return false;
               
            }

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
                        Console.WriteLine($"You check the processes running and see {this.process} {this.processName} tabs are open.\n");
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
                    default:
                        break;
                }
            }
            
        }

        //North Room Final PC problem
        public bool initPCRoomNorth()
        {
            Console.WriteLine("You initiate the north room PC problem\n\n");
            bool isFixed = false;
            Console.WriteLine("You approach the final computer in the game.  Unlike any problem you have seen before.");
            Console.WriteLine("Fix this issue and you can go home and eat pizza.\n");
            Console.WriteLine("The computer belongs to Steven. A self proclaimed developer.  \nHe needs you to do everything for him so he can maybe do his job.\n");
            Console.WriteLine("At first glance, you see dandruff all over the PC.\n");
            Console.WriteLine("Set up his computer and get out of here.\n");

            while (!isFixed)
            {
                printNorthMenu();
                string choice = Console.ReadLine();
                switch(choice)
                {
                    case "1":
                        this.taskChecker();
                        break;
                    case "2":
                        Console.WriteLine("You begin to install VSCode. Real glad you work in IT right now?");
                        this.installVSCode();
                        break;
                    case "3":
                        if(this.getNPM() == true)
                        {
                            Console.WriteLine("Congrats. Typescript is now installed");
                            this.installTypeScript();
                        }
                        else
                        {
                            Console.WriteLine("You need to install npm first before installing trypescript");
                        }
                        break;
                    case "4":
                        Console.WriteLine("You go ahead and install npm for the royal highness");
                        this.installNPM();
                        break;
                    case "5":
                        Console.WriteLine("His code is garbage");
                        break;
                    case "6":
                        Console.WriteLine("You leave the computer");
                        return false;
                    case "7":
                        Console.WriteLine("Checking that everything is installed...\n");
                        System.Threading.Thread.Sleep(2000);
                        Console.WriteLine($"VSCode... {this.VSCode}\n");
                        System.Threading.Thread.Sleep(2000);
                        Console.WriteLine($"TypeScript... {this.typeScript}\n");
                        System.Threading.Thread.Sleep(2000);
                        Console.WriteLine($"NPM... {this.npm}\n");
                        System.Threading.Thread.Sleep(2000);
                        isFixed = this.checkInstalls();
                        if (isFixed)
                        {
                            Console.WriteLine("Looks like everything is installed.  Good job.");

                            return true;
                        }
                        else
                        {
                            continue;
                        }
                    case "fix":
                        return true;
                    default:
                        break;
                }
            }
            return true;
           
        }

        public void printMenuWest()
        {
            
            Console.WriteLine("You can:\n1.Restart the computer \n2.Check Task Manager \n3.Pull the plug \n4.Leave \n5.Check overall speed \n");
        }

        public void printMenuEast()
        {

            Console.WriteLine("What would you like to do?\n");
            Console.WriteLine("1. Turn the computer on  \n2. Check if it's plugged in \n3. Turn the computer on and enter BIOS \n4. Smell the Computer \n5. Hit the Computer \n6. Leave Computer\n");

        }

        public void printTaskMenu()
        {

            Console.WriteLine("1.Process \n2.Performance \n3.Start Up \n4.Quit \n");
        }

        public void printNorthMenu()
        {
            Console.WriteLine("\nYou can:\n1.Check Task Manager \n2.Install VSCode \n3.Install TypeScript \n4.Install npm \n5.Sneak a look at his code \n6.Leave this computer \n7.Check Installs");
        }

        public double checkPerform()
        {
            return this.performance = (this.process + this.startUp) + 10;
        }

        //Getters and Setters for installs
        public bool getVSCode()
        {
            return this.VSCode;
        }

        public bool getTypeScript()
        {
            return this.typeScript;
        }

        public bool getNPM()
        {
            return this.npm;
        }

        public void installVSCode()
        {
            this.VSCode = true;
        }

        public void installTypeScript()
        {
            this.typeScript = true;
        }

        public void installNPM()
        {
            this.npm = true;
        }

        public bool checkInstalls()
        {
            if(this.getNPM() == true && this.getTypeScript() == true && this.getVSCode() == true)
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
