﻿using QR_game.Objects.Interfaces;
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
            _sprite = new AnimatedSprite(Textures.Test, 0, 0, 32, 32, 1);
            _sprite.Frame = 1;
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
