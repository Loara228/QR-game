using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using QR_game.Objects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QR_game
{
    public class Controller
    {
        public Controller()
        {

        }

        // from - physics object
        public void Update(PhysicsObject from)
        {
            if (Keyboard.Down(Keys.D))
            {
                from.velocity.X += ACCELERATION;
            }
            else if (Keyboard.Down(Keys.A))
            {
                from.velocity.X -= ACCELERATION;
            }
            if (Keyboard.Down(Keys.S))
            {
                from.velocity.Y += ACCELERATION;
            }
            else if (Keyboard.Down(Keys.W))
            {
                from.velocity.Y -= ACCELERATION;
            }
        }

        private const float ACCELERATION = 2f;
    }
}
