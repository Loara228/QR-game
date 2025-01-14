using QR_game.Objects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QR_game.Objects
{
    public class Block : PhysicsObject
    {
        public Block(float x, float y) : base(x, y)
        {
            _sprite = new AnimatedSprite(Textures.GetTexture("test"), 0, 0, 32, 32, 1);
            Width = 32;
            Height = 32;
            Collidable = true;
        }

        public override void Draw()
        {
            base.Draw();
        }

        public override void Update()
        {
            base.Update();
        }
    }
}
