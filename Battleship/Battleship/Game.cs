using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    public class Game
    {
        BattleField battlefield;
        Player player1;
        Player player2;
        public string templateOutput = "{0} fires a missile with target {1} which got {2}";
        public enum results
        {
            Hit=1,
            Miss=2,
            Draw=3
            

        }
        public Game(BattleField battlefield, Player player1, Player player2)
        {
            this.battlefield = battlefield;
            this.player1 = player1;
            this.player2 = player2;
        }

        public void Begin()
        {
            //One by One Lets Fire those Missiles :D
            while (player1.shots.Count >= 0 || player2.shots.Count >= 0)
            {
                int result = 0;
                //In One Round, Player 1 takes the first shot
               result=  FireMissile(player1, player2);

                if(result==1)
                {
                    while (result == 1)
                    {
                     result= FireMissile(player1, player2);
                    }
                }
                if(result==3)
                {
                    break;
                }
                //Player 2 goes next and takes his best shot
                result =FireMissile(player2, player1);
                if (result == 1)
                {
                    while (result == 1)
                    {
                        result = FireMissile(player2, player1);
                    }
                   
                }
                if (result == 3)
                {
                    break;
                }


            }
        }



        public int FireMissile(Player playerFiring, Player playerBeingHit)
        {

            if(playerFiring.shots.Count == 0 && playerBeingHit.shots.Count == 0)
            {
                Console.WriteLine("{0} and {1} has no more missiles left to launch", playerFiring.name,playerBeingHit.name);
                return (int)results.Draw;
            }

           else if (playerFiring.shots.Count == 0)
            {
                Console.WriteLine("{0} has no more missiles left to launch", playerFiring.name);
                
            }
            else
            {
                Coordinates targetCoordinate = playerFiring.shots.Dequeue();
                if (playerBeingHit.Hit(targetCoordinate) == true)
                {
                    Console.WriteLine(String.Format(templateOutput, playerFiring.name, targetCoordinate.GetFriendlyName(), "hit"));
                    return (int)results.Hit;
                }
                Console.WriteLine(String.Format(templateOutput, playerFiring.name, targetCoordinate.GetFriendlyName(), "miss"));
                return (int)results.Miss;
            }
            return 0;
        }


    }
}
