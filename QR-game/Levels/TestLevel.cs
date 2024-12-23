using QR_game.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QR_game.Levels
{
    public class TestLevel : Level
    {
        public TestLevel()
        {
            Block b = null;
            this.Add(b = new Block(150, 130)
            {
                Width = 32f,
                Height = 32f
            });
            this.Add(new Player(200, 200));
        }
    }
}
