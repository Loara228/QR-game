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
            this.AddObject(new Block(30, 30));
        }
    }
}
