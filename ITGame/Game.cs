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
                Console.WriteLine($"What do you want to do?\nYou can type 'help' for a list of what you can do.\n");

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
                    case "q":
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
                        if(curRoom.getNorth() != null)
                        {
                            if (!curRoom.getNorth().getLocked())
                            {
                                player.setCurrentRoom(curRoom.getNorth());
                                Console.WriteLine($"You head towards the North");
                            }
                            else if (curRoom.getNorth().getLocked())
                            {
                                Console.WriteLine("You can't go that way. The door is locked.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("You can't go that way. There is no room.");
                        }
                        break;
                    case "down":
                        if (curRoom.getSouth() != null)
                        {
                            if (!curRoom.getSouth().getLocked())
                            {
                                player.setCurrentRoom(curRoom.getSouth());
                                Console.WriteLine($"You have finished all your tasks.  You leave the building.");
                            }
                            else if (curRoom.getSouth().getLocked())
                            {
                                Console.WriteLine("You can't go that way. The door is locked.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("You can't go that way. There is no room.");
                        }
                        break;
                    case "h":
                    case "help":
                        readFile("Verbs");
                        break;
                    case "go to pc":
                        if(curRoom.getPC() != null && curRoom.getRoomSolved() == false)
                        {
                            //Add functions for other rooms
                            Console.WriteLine("You head towards the computer");
                            if (curRoom.getPC().getPCName().Equals("eastRoomPC"))
                            {
                                if (curRoom.getPC().initPCLoopEast())
                                {
                                    curRoom.setRoomSolved();
                                }
                                else
                                {
                                    continue;
                                }
                                
                            }
                            else if (curRoom.getPC().getPCName().Equals("westRoomPC"))
                            {
                                
                                if (curRoom.getPC().getPCName().Equals("westRoomPC"))
                                {
                                    if (curRoom.getPC().initPCRoomWest())
                                    {
                                        curRoom.setRoomSolved();
                                    }
                                    else
                                    {
                                        continue;
                                    }

                                }
                            }
                            else if (curRoom.getPC().getPCName().Equals("northRoomPC"))
                            {
                                curRoom.getPC().initPCRoomNorth();
                            }
                            else
                            {
                                Console.WriteLine("What Computer are you trying to go to?");
                            }
                            
                        }
                        else if (curRoom.getRoomSolved() == false){
                            Console.WriteLine("There are no computers to fix in this room.");
                        }
                        else
                        {
                            Console.WriteLine("You cannot go to a pc at this time");
                        }
                        break;
                    case "yell":
                        Console.WriteLine("Why are you yelling?");
                        break;
                    default:
                        Console.WriteLine($"The command {playerChoice} was not recognized\n");
                        Console.WriteLine("Type 'help' or 'h' for a list of commands");
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
