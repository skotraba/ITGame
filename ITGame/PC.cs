using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//PC class for the problem that will be in each room

namespace ITGame
{

    // Create a start function for the PC class
    // should be similar to the main game start loop (gets user input, responds to it)
    // start with something basic 
    //   (create a list off commands you can run at the pc, similar to look, move, help for the main game)
    // when the user is done at the computer, exit the loop, this will return control to the main game loop
    // PC.start() will be called from the main game loop, and resume control when the PC start loop finishes


    class PC
    {
        private string name;
        private string message;

        public PC(string name)
        {
            this.name = name;
        }

        public string getPCName()
        {
            return this.name;
        }

        public void initPCLoopEast()
        {
            Console.WriteLine("You are looking at Barb's computer.  \nShe's complaining that it won't turn on.  \nYou look at the computer and the screen is black");
            Console.WriteLine("You need to troubleshoot the computer to leave the room, what would you like to do?");
            Console.WriteLine("1. Turn the computer on  \n2. Check if it's plugged in \n3. Turn the computer on and enter BIOS \n4. Smell the Computer \n5.Hit the Computer");
            
            
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

            
        }
    }
}
