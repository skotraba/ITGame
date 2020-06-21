using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Need a locked door function
//Problems for each room
//Randomize output for certain things


namespace ITGame
{
    class Game
    {
        private bool running = true;
        private Player player;
        private Map map;
       
        public void initialize()
        {
            map = new Map();
            
            Console.WriteLine("Welcome to ITTTTTT Simulator.\nWhat's your name?");
            string playerName;
            playerName = Console.ReadLine();

            player = new Player();
            player.setName(playerName);
            player.setCurrentRoom(map.getMainRoom());
            
            Console.WriteLine($"Hello {playerName}. You look fresh.\n");
        }

        public void start()
        {
            while (running)
            {
                Console.WriteLine($"What do you want to do?\n");

                string playerChoice = Console.ReadLine();
                Room curRoom = player.getCurrentRoom();
                switch (playerChoice)
                {
                    case "look":
                        player.lookAround();
                        break;
                    case "dev":
                        player.getCurrentRoom().printDebug();
                        break;
                    case "exit":
                        running = false;
                        break;
                    case "west":
                    case "left":
                        if(curRoom.getWest() != null)
                        {
                            player.setCurrentRoom(curRoom.getWest());
                            Console.WriteLine($"You head towards the {player.getCurrentRoom().getName()}");
                        }
                        else
                        {
                            Console.WriteLine("You can't go that way. There is no room.");
                        }
                        break;
                    case "east":
                    case "right":
                        if (curRoom.getEast() != null)
                        {
                            player.setCurrentRoom(curRoom.getEast());
                            Console.WriteLine($"You head towards the {player.getCurrentRoom().getName()}");
                        }
                        else
                        {
                            Console.WriteLine("You can't go that way. There is no room.");
                        }
                        break;
                    case "up":
                    case "straight":
                        if (curRoom.getNorth() != null)
                        {
                            player.setCurrentRoom(curRoom.getNorth());
                            Console.WriteLine($"You head towards the North");
                        }
                        else
                        {
                            Console.WriteLine("You can't go that way. There is no room.");
                        }
                        break;
                    case "down":
                        if (curRoom.getSouth() != null)
                        {
                            player.setCurrentRoom(curRoom.getSouth());
                            Console.WriteLine($"You head towards the {player.getCurrentRoom().getName()}");
                        }
                        //This is broken. Need to add field of locked instead of null;
                        else if (curRoom.getSouth().getName().Equals(map.getSouthRoom().getName()))
                        {
                            Console.WriteLine("That door is locked. You cannot leave until you finish all your tasks");
                        }
                        else
                        {
                            Console.WriteLine("You can't go that way. There is no room.");
                        }
                        break;
                    case "help":
                        readFile("Verbs");
                        break;
                    case "go to pc":
                        if(curRoom.getPC() != null)
                        {
                            Console.WriteLine("You head towards the computer");
                            // TODO: this is where you can call the PC's start loop
                            curRoom.getPC().initPCLoopEast();
                            // control will be switched to the PC's loop until that loop is finished (the user exits the PC)
                            // curRoom.getPC().start()
                        }
                        else
                        {
                            Console.WriteLine("There is no computer in this room");
                        }
                        break;
                    case "yell":
                        Console.WriteLine("Why are you yelling?");
                        break;
                    default:
                        break;
                }
                
            }

        }


        public void readFile(string fileName)
        {
            int counter = 0;
            string line;

            //Read file and display line by line
            System.IO.StreamReader file = new System.IO.StreamReader($"../../{fileName}.txt");
            while ((line = file.ReadLine()) != null)
            {
                System.Console.WriteLine(line);
                counter++;
            }
            file.Close();
        }

    }
}
