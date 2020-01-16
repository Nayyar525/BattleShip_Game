using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    public class BattleField
    {
        int width;
        int height;

        public BattleField(string dimensions)
        {
            this.width = Convert.ToInt32(dimensions[0].ToString());
            this.height = (Convert.ToInt32(dimensions[2]) - 64);
        }
    }
}
