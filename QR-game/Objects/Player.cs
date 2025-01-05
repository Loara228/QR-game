using Microsoft.Xna.Framework.Input;
using QR_game.Objects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QR_game.Objects
{
    public class Player : Entity
    {
        public Player(float x, float y) : base(x, y)
        {
            _sprite = new AnimatedSprite(Textures.Player, 0, 0, 32, 64, 1);
            _controller = new Controller();
            Width = 64;
            Height = 128;
            Team = Enemies.Team.Allies;
            Damage = 52;
        }

        public override void Draw()
        {
            base.Draw();
        }

        public override void Update()
        {
            _controller.Update(this);
            if (Keyboard.Pressed(Keys.D))
                _sprite.Flip = false;
            else if (Keyboard.Pressed(Keys.A))
                _sprite.Flip = true;
            base.Update();
        }

        protected override void OnDamage(int value)
        {
            base.OnDamage(value);
        }

        private Controller _controller;
    }
}
