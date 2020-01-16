using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    class Program
    {
        static void Main(string[] args)
        {

            //First Create the BattleField
            string battleFieldDimensions = Console.ReadLine();
            BattleField battleField = new BattleField(battleFieldDimensions);

            //Create the 2 Players
            Player player1 = new Player("Player-1");
            Player player2 = new Player("Player-2");

            int noOfBattleShipsForEachPlayer = Convert.ToInt32(Console.ReadLine());
            List<IShip> player1Ships = new List<IShip>();
            List<IShip> player2Ships = new List<IShip>();

            for (int i = 0; i < noOfBattleShipsForEachPlayer; i++)
            {
                string inputLine = Console.ReadLine();
                string[] inputs = inputLine.Split(' ');
                char shipType = Convert.ToChar(inputs[0]);
                int shipWidth = Convert.ToInt32(inputs[1]);
                int shipHeight = Convert.ToInt32(inputs[2]);
                Coordinates player1Coordinates = new Coordinates(inputs[3]);
                Coordinates player2Coordinates = new Coordinates(inputs[4]);

                player1.AddShip(ShipFactory.GetShip(shipType, player1Coordinates, shipHeight, shipWidth));
                player2.AddShip(ShipFactory.GetShip(shipType, player2Coordinates, shipHeight, shipWidth));

            }

            Queue<Coordinates> player1Shots = new Queue<Coordinates>();
            Queue<Coordinates> player2Shots = new Queue<Coordinates>();

            string player1ShotsInput = Console.ReadLine();
            string[] player1ShotsSplit = player1ShotsInput.Split(' ');
            for (int i = 0; i < player1ShotsSplit.Length; i++)
            {
                player1.shots.Enqueue(new Coordinates(player1ShotsSplit[i]));
            }
            

            string player2ShotsInput = Console.ReadLine();
            string[] player2ShotsSplit = player2ShotsInput.Split(' ');
            for (int i = 0; i < player2ShotsSplit.Length; i++)
            {
                player2.shots.Enqueue(new Coordinates(player2ShotsSplit[i]));
            }


            Game game = new Game(battleField, player1, player2);
            game.Begin();
            Console.ReadLine();
            
        }
    }
}
