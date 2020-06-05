using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Player should be able to check which room they are in
//Look around room (search)
//Check inventory





namespace ITGame
{
    class Player
    {
        string name;
        string[] inventory;
        Room currentRoom;

        public Player()
        {
            this.name = "";
            this.currentRoom = null;
        }



        public void setName(string tempName)
        {
            this.name = tempName;
        }

        public string getName()
        {
            return this.name;
        }

        public void setCurrentRoom(Room room)
        {
            this.currentRoom = room;
        }

        public Room getCurrentRoom()
        {
            return this.currentRoom;
        }

        public void lookAround()
        {
            this.currentRoom.description();
        }

        //public void move(string direction)
        //{
        //    switch (direction)
        //    {
        //        case "left":
        //            Console.WriteLine("You go left");
        //            break;
        //        case "right":
        //            Console.WriteLine("You go right");
        //            break;
        //        case "up":
        //        case "straight":
        //            Console.WriteLine("You straight");
        //            break;
        //        case "down":
        //            Console.WriteLine("You go down");
        //            break;
        //        default:
        //            Console.WriteLine("Not a valid direction");
        //            break;
        //    }
        //}
    }
}
