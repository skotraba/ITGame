using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITGame
{
    class Game
    {
        private bool running = true;
        private Player player;

        private Room mainRoom;
        private Room eastRoom;
        private Room westRoom;
        private Room northRoom;
        private Room southRoom;


        public void initialize()
        {
             northRoom = new Room("north");
             eastRoom = new Room("east");
             westRoom = new Room("west");
            southRoom = null;
            

            mainRoom = new Room("main", northRoom, eastRoom, westRoom, southRoom);
            northRoom.setSouth(mainRoom);
            eastRoom.setWest(mainRoom);
            westRoom.setEast(mainRoom);



            Console.WriteLine("Welcome to ITTTTTT Simulator. What's your name?");
            string playerName;
            playerName = Console.ReadLine();

            player = new Player();
            player.setName(playerName);
            player.setCurrentRoom(mainRoom);
            

            Console.WriteLine($"Hello {playerName}. You look fresh.");
        }

        public void start()
        {
            while (running)
            {
                
           
                Console.WriteLine($"You are currently in the {player.getCurrentRoom().name} room. What do you want to do?");

                string playerChoice = Console.ReadLine();

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
                    case "left":
                        player.setCurrentRoom(player.getCurrentRoom().getWest());
                        Console.WriteLine($"You head towards the {player.getCurrentRoom().name}");
                        break;
                    case "right":
                        player.setCurrentRoom(player.getCurrentRoom().getEast());
                        Console.WriteLine($"You head towards the {player.getCurrentRoom().name}");
                        break;
                    case "up":
                    case "straight":
                        player.setCurrentRoom(player.getCurrentRoom().getNorth());
                        Console.WriteLine($"You head towards the {player.getCurrentRoom().name}");
                        break;
                    case "down":
                        player.setCurrentRoom(player.getCurrentRoom().getSouth());
                        Console.WriteLine($"You head towards the {player.getCurrentRoom().name}");
                        break;

                    default:
                        break;
                }
                
            }
        }

    }
}
