using QR_game.Drawing;
using QR_game.Objects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QR_game.Objects.Drop
{
    public class Drop : PhysicsObject
    {
        public Drop(float x, float y) : base(x, y)
        {
            this.Collidable = true;
            this.StaticObject = true;
            this._sprite = new AnimatedSprite(Textures.GetTexture("drop"), [null]);
            this.IgnoreCollision = true;
        }

        protected override void Touch(TouchSide side, PhysicsObject from)
        {
            if (from is Player)
            {
                Game1.CurrentLevel.Remove(this);
            }
        }

        public override void Update()
        {
            base.Update();
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
