using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    public  class ShipFactory
    {
         public static IShip GetShip(char type, Coordinates coordinates, int height, int width)
        {
            IShip ship = null;
            switch (type)
            {
                case 'P':
                    ship = new Ship(coordinates, height, width, 1);
                    break;
                case 'Q':
                    ship = new Ship(coordinates, height, width, 2);
                    break;
            }
            return ship;
        }
    }
}
