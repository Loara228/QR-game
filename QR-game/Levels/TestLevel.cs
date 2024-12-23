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
            this.AddObject(b = new Block(150, 130)
            {
                Width = 60f,
                Height = 20f
            });
        }
    }
}
