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

        public void initialize()
        {
            Room northRoom = new Room("north");
            Room eastRoom = new Room("east");
            Room westRoom = new Room("west");
            Room southRoom = null;

            Room mainRoom = new Room("main", northRoom, eastRoom, westRoom, southRoom);

            Console.WriteLine("Welcome to It Simulator. What's your name?");
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
                    default:
                        break;
                }
                
            }
        }

    }
}
