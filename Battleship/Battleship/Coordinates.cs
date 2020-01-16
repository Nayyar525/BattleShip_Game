using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    public class Coordinates
    {
        public int x;
        public int y;

        public Coordinates(string coordinates)
        {
            this.y = Convert.ToInt32(coordinates[1].ToString());
            this.x = Convert.ToInt32(coordinates[0]) - 64;

        }


        public Coordinates(int x, int y)
        {
            this.x = x;
            this.y = y;

        }

        public string GetFriendlyName()
        {
            return (Convert.ToChar(this.x + 64) + "" +  this.y).ToString();
        }

        


        public Coordinates AddRow(int r)
        {
            Coordinates localCopy = new Coordinates(this.x, this.y);
            //localCopy.y = localCopy.y + r;
            localCopy.x = localCopy.x + r;
            return localCopy;
        }

        public Coordinates AddColumn(int c)
        {
            Coordinates localCopy = new Coordinates(this.x, this.y);
            //localCopy.x = localCopy.x + c;
            localCopy.y = localCopy.y + c;
            return localCopy;
        }
    }
}
