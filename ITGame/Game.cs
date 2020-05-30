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

            player.getCurrentRoom().printDebug();

            Console.WriteLine($"Hello {playerName} Welcome to It Simulator");
            Console.ReadLine();
        }

        public void start()
        {
            while (running)
            {
                Console.WriteLine($"You are currently in the {player.getCurrentRoom().name} room. What do you want to do?");

                string playerChoice = Console.ReadLine();

                if (playerChoice.Equals("look"))
                {
                    player.lookAround();
                }

                //while (!(playerChoice.Equals("left") || playerChoice.Equals("right") || playerChoice.Equals("straight")))
                //{
                //    Console.WriteLine("Please type 'left', 'right' or 'straight'");
                //    playerChoice = Console.ReadLine();
                //}

                //if (playerChoice == "left")
                //{
                //    Console.WriteLine("Okay, you are in the left room");
                //    Console.ReadLine();
                //}
                //else if (playerChoice == "right")
                //{
                //    Console.WriteLine("Okay, you are in the right room");
                //    Console.ReadLine();
                //}
                //else if (playerChoice == "straight")
                //{
                //    Console.WriteLine("Okay, you straight");
                //    Console.ReadLine();
                //}

                //Console.WriteLine($"You head {playerChoice} ");
                //Console.ReadLine();
            }
        }

    }
}
