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
            AddBorder();
            this.Add(new EnemyQR(550, 200));
            this.Add(new Block(500, 100) { Height = 150 });
            // стенка врагов
            //this.Add(new EnemyQR(550, 200));
            //this.Add(new EnemyQR(600, 200));
            //this.Add(new EnemyQR(650, 200));
            //this.Add(new EnemyQR(700, 200));
            // со всех сторон
            //this.Add(new EnemyQR(550, 200));
            //this.Add(new EnemyQR(-550, -200));
            //this.Add(new EnemyQR(550, -900));
            //this.Add(new EnemyQR(-550, 700));
        }

        private void AddBorder()
        {
            this.Add(new Block(-1000, -1000)
            {
                Width = 2000
            });
            this.Add(new Block(-1000, -1000)
            {
                Height = 2000
            });
            this.Add(new Block(-1000, 1000)
            {
                Width = 2000
            });
            this.Add(new Block(1000, -1000)
            {
                Height = 2000
            });
        }
    }
}
