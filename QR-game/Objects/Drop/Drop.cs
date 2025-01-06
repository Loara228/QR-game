using QR_game.Objects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QR_game.Objects.Drop
{
    public class Drop : GameObj
    {
        public Drop(float x, float y) : base(x, y)
        {

        }

        public override void Update()
        {
            // if in range
            //  magnetize
            // if in min range
            //  pickup
        }

        public override void Draw()
        {
            base.Draw();
        }
    }
}
