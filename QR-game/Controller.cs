using Microsoft.Xna.Framework.Input;
using QR_game.Objects;

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
            if (Keyboard.Pressed(Keys.A))
                _dir = Dir.Left;
            else if (Keyboard.Pressed(Keys.D))
                _dir = Dir.Right;

            bool f1 = false, f2 = false, f3 = false, f4 = false;

            if (f1 = Keyboard.Down(Keys.D))
            {
                if (_dir == Dir.Right)
                {
                    from.HSpeed += ACCELERATION;
                    _flip = false;
                }
            }
            if (f2 = Keyboard.Down(Keys.A))
            {
                if (_dir == Dir.Left)
                {
                    from.HSpeed -= ACCELERATION;
                    _flip = true;
                }
            }
            if (f3 = Keyboard.Down(Keys.S))
            {
                from.VSpeed += ACCELERATION;
            }
            if (f4 = Keyboard.Down(Keys.W))
            {
                from.VSpeed -= ACCELERATION;
            }

            _anyKeyDown = f1 || f2 || f3 || f4;

            float speed = from.Speed();
            if (speed > 0)
            {
                //if (speed > from.max_speed)
                //    speed = from.max_speed;
                //from.Velocity.Normalize();
                //from.Velocity *= speed;

            }
        }

        public bool AnyKey
        {
            get => _anyKeyDown;
        }

        public bool Flip
        {
            get => _flip;
        }

        public Dir EyeDirection
        {
            get => _dir;
        }

        private Dir _dir = Dir.Right; // horizontal
        private bool _anyKeyDown = false;
        private bool _flip = true;
        private const float ACCELERATION = 0.75f;

        public enum Dir : sbyte
        {
            Left = -1,
            None = 0,
            Right = 1
        }
    }
}
