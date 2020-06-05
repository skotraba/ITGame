using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITGame
{
    class Map
    {

        private Room mainRoom;
        private Room eastRoom;
        private Room westRoom;
        private Room northRoom;
        private Room southRoom;

        private PC eastRoomPC;

        public Map()
        {

            eastRoomPC = new PC("Power PC");

            northRoom = new Room("north");
            eastRoom = new Room("east", eastRoomPC);
            westRoom = new Room("west");
            southRoom = null;


            mainRoom = new Room("main", northRoom, eastRoom, westRoom, southRoom);
            northRoom.setSouth(mainRoom);
            eastRoom.setWest(mainRoom);
            westRoom.setEast(mainRoom);

        }

        public Room getMainRoom()
        {
            return mainRoom; 
        }

        public Room getEastRoom()
        {
            return eastRoom;
        }

        public Room getWestRoom()
        {
            return westRoom;
        }

        public Room getSouthRoom()
        {
            return southRoom;
        }

        public Room getNorthRoom()
        {
            return northRoom;
        }


    }
}
