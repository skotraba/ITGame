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
        private PC westRoomPC;
        private PC northRoomPC;

        public Map()
        {

            eastRoomPC = new PC("eastRoomPC");
            westRoomPC = new PC("westRoomPC");
            northRoomPC = new PC("northRoomPC");

            northRoom = new Room("north", northRoomPC, true);
            eastRoom = new Room("east", eastRoomPC, false);
            westRoom = new Room("west", westRoomPC, false);
            southRoom = new Room("south", null, true);


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
