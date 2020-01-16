using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    public class Ship : IShip
    {
        public Coordinates coordinates;
        public int height;
        public int width;
        public int hitsToKill;
        public void hit()
        {
            hitsToKill--;
        }
        public List<Coordinates> coordinatesCoveredByShip;

     

        public Ship(Coordinates coordinates, int height, int width, int hitsToKill)
        {
            this.coordinates = coordinates;
            this.height = height;
            this.width = width;
            this.hitsToKill = hitsToKill;
            coordinatesCoveredByShip = new List<Coordinates>();
            for (int i = 0; i < height; i++)
            {
                Coordinates nextRowCoordinate = coordinates.AddRow(i);
                for (int k = 0; k < width; k++)
                {
                    Coordinates nextCoordinate = coordinates.AddColumn(k);
                    for (int j = 0; j < hitsToKill; j++)
                    {
                        coordinatesCoveredByShip.Add(nextCoordinate);
                    }
                }
            }
        }

        public bool HasCoordinateCovered(Coordinates search)
        {
            foreach (Coordinates c in coordinatesCoveredByShip)
            {
                if (c.x == search.x && c.y == search.y)
                {
                    coordinatesCoveredByShip.Remove(c);
                    return true;
                }
            }

            return false;
        }


    }
}
