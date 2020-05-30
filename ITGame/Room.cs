using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITGame
{
    class Room
    {
        public string name;
        public Room north;
        public Room east;
        public Room south;
        public Room west;

        //Room constructor, each room has a direction that can be null or point to another room
        public Room(string name)
        {
            this.name = name;
            this.north = null;
            this.east = null;
            this.west = null;
            this.south = null;
        }

        public Room(string name, Room northRoom, Room eastRoom, Room westRoom, Room southRoom)
        {
            this.name = name;
            this.north = northRoom;
            this.east = eastRoom;
            this.west = westRoom;
            this.south = southRoom;
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

        public void description()
        {
            if (this.north != null)
            {
                Console.WriteLine($"There is a door that leads to the {this.north.name}");
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
        }

        // DEBUGGING ONLY. ROCKETS
        public void printDebug()
        {
            Console.WriteLine($"We are in the {this.name} room");

            if (this.north != null)
            {
                Console.WriteLine($"There is a door that leads to the {this.north.name}");
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
        }

    }
}
