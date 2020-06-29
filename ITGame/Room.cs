using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITGame
{
    class Room
    {
        private string name;
        private PC roomPC;
        private Room north;
        private Room east;
        private Room south;
        private Room west;
        private bool isSolved = false;
        private bool isLocked;

        //Room constructor, each room has a direction that can be null or point to another room
        public Room(string name)
        {
            this.name = name;
            this.north = null;
            this.east = null;
            this.west = null;
            this.south = null;
            this.roomPC = null;
        }

        public Room(string name, PC thisRoomPc, bool locked)
        {
            this.name = name;
            this.north = null;
            this.east = null;
            this.west = null;
            this.south = null;
            this.roomPC = thisRoomPc;
            this.isLocked = locked;
        }

        public Room(string name, Room northRoom, Room eastRoom, Room westRoom, Room southRoom)
        {
            this.name = name;
            this.north = northRoom;
            this.east = eastRoom;
            this.west = westRoom;
            this.south = southRoom;
        }
        

        public string getName()
        {
            return this.name;
        }

        public void setNorth(Room northRoom)
        {
            this.north = northRoom;
        }

        public void setEast(Room eastRoom)
        {
            this.east = eastRoom;
        }

        public void setWest(Room westRoom)
        {
            this.west = westRoom;
        }

        public void setSouth(Room southRoom)
        {
            this.south = southRoom;
        }

        public Room getNorth()
        {
            return north;
        }

        public Room getSouth()
        {
            return south;
        }

        public Room getEast()
        {
            return east;
        }

        public Room getWest()
        {
            return west;
        }

        public void description()
        {
            if (this.north != null)
            {
                Console.WriteLine($"There is a door to the north");
            }
            if (this.east != null)
            {
                Console.WriteLine($"There is a door to the east");
            }
            if (this.west != null)
            {
                Console.WriteLine($"There is a door to the west");
            }
            if (this.south != null)
            {
                Console.WriteLine($"There is a door to the south");
            }
            if(this.roomPC != null)
            {
                Console.WriteLine($"You see a computer sitting alone in the room");
            }
        }

        // DEBUGGING ONLY. ROCKETS
        public void printDebug()
        {
            Console.WriteLine($"\nWe are in the {this.name} room");

            if (this.north != null)
            {
                Console.WriteLine($"There is a door that leads to the {this.north.name}");
                Console.WriteLine($"This North room locked: {this.getNorth().isLocked}");
            }
            if (this.east != null)
            {
                Console.WriteLine($"There is a door that leads to the {this.east.name}");
            }
            if (this.west != null)
            {
                Console.WriteLine($"There is a door that leads to the {this.west.name}");
            }
            if (this.south != null)
            {
                Console.WriteLine($"There is a door that leads to the {this.south.name}");
            }
            Console.WriteLine($"This room status: {this.isSolved}");
            Console.WriteLine($"This room locked: {this.isLocked}");
            

        }

        public PC getPC()
        {
            return this.roomPC;
        }

        public bool getRoomSolved()
        {
            return this.isSolved;
        }

        public void setRoomSolved()
        {
            this.isSolved = true;
        }


        public bool getLocked()
        {
            return this.isLocked;
        }

        public void unlockRoom()
        {
            this.isLocked = false;
        }

    }
    }
    

