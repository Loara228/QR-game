using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QR_game
{
    public static class Keyboard
    {
        static Keyboard()
        {
            _released = new List<Keys>();
        }

        public static void Update()
        {
            _released.Clear();

            _state = Microsoft.Xna.Framework.Input.Keyboard.GetState();
            _pressed = _state.GetPressedKeys();
        }

        public static bool Pressed(Keys key) => _pressed.Contains(key);
        public static bool Down(Keys key) => _state.IsKeyDown(key);

        private static Keys[] _pressed;
        private static List<Keys> _released;
        private static KeyboardState _state;

    }
}
