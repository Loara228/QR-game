using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using QR_game.Objects.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                from.HSpeed += ACCELERATION;
            }
            else if (Keyboard.Down(Keys.A))
            {
                from.HSpeed -= ACCELERATION;
            }
            if (Keyboard.Down(Keys.S))
            {
                from.VSpeed += ACCELERATION;
            }
            else if (Keyboard.Down(Keys.W))
            {
                from.VSpeed -= ACCELERATION;
            }

            float speed = from.Speed();
            if (speed > 0)
            {
                //if (speed > from.max_speed)
                //    speed = from.max_speed;
                //from.Velocity.Normalize();
                //from.Velocity *= speed;

            }
        }

        private const float ACCELERATION = 0.75f;
    }
}
