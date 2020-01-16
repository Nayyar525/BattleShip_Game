using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    public class Player
    {
        public string name;
        List<IShip> ships;

        public Player(string name)
        {
            this.name = name;
            this.ships = new List<IShip>();
            shots = new Queue<Coordinates>();
        }

        public void AddShip(IShip ship)
        {
            this.ships.Add(ship);
        }

        public Queue<Coordinates> shots;



        public bool Hit(Coordinates c)
        {
            //If there is any ship on the given coordinate then it counts as a hit, return true
            foreach (Ship ship in ships)
            {
                if (ship.HasCoordinateCovered(c))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
