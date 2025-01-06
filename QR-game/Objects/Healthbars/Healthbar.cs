using Microsoft.Xna.Framework;
using QR_game.Objects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QR_game.Objects.Healthbars
{
    public abstract class Healthbar : Interfaces.IDrawable
    {
        public Healthbar(Entity owner)
        {
            _owner = owner;
        }

        public abstract void Draw();

        protected Entity _owner;
    }
}
