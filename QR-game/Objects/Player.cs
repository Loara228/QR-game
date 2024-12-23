using QR_game.Objects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QR_game.Objects
{
    public class Player : PhysicsObject
    {
        public Player(float x, float y) : base(x, y)
        {
            _sprite = new AnimatedSprite(Textures.Player, 0, 0, 32, 64, 1);
            _controller = new Controller();
            Width = 32;
            Height = 64;
        }

        public override void Draw()
        {
            base.Draw();
        }

        public override void Update()
        {
            base.Update();
            _controller.Update(this);
        }

        private Controller _controller;
    }
}
