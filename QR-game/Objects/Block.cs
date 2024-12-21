using QR_game.Objects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QR_game.Objects
{
    public class Block : GameObj
    {
        public Block(float x, float y) : base(x, y)
        {
            _texture = Textures.Test;
            Width = 30;
            Height = 30;
        }

        public override void Draw()
        {
            base.Draw();
        }

        public override void Update()
        {

        }
    }
}
