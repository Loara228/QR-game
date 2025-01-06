using QR_game.Objects;
using QR_game.Objects.Enemies;
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
            this.Add(new Block(150, 130));
            this.Add(new EnemyQR(350, 200));
            this.Add(new EnemyQR(450, 200));
            this.Add(new EnemyQR(550, 200));
        }
    }
}
