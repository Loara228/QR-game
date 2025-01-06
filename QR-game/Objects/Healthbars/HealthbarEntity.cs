using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QR_game.Objects.Healthbars
{
    internal class HealthbarEntity : Healthbar
    {
        public HealthbarEntity(Entity owner) : base(owner)
        {

        }

        public override void Draw()
        {
            var rect = new Rectangle(
                (int)_owner.X,
                (int)((int)_owner.Y - _offset),
                (int)_owner.Width,
                (int)_size);
            var rect_hp = new Rectangle(
                    rect.X - 1,
                    rect.Y - 1,
                    rect.Width + 2,
                    rect.Height + 2);
            rect_hp.Width = (int)((float)rect_hp.Width / (float)_owner.MaxHealth * (float)_owner.Health);

            Graphics.FillRectangle(
                rect,
                Color.Black);
            Graphics.FillRectangle(
                rect_hp,
                Color.Red);
        }

        protected float _offset = 6;
        private float _size = 4;
    }
}
