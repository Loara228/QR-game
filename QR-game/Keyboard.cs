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
            _pressed = new List<Keys>();
            _held = new List<Keys>();
            _released = new List<Keys>();
        }

        public static void Update()
        {
            _pressed.Clear();
            _released.Clear();

            var pressedKeys = Microsoft.Xna.Framework.Input.Keyboard.GetState().GetPressedKeys();

            foreach(Keys key in pressedKeys)
                if (!_held.Contains(key))
                    _pressed.Add(key);

            foreach (Keys key in _held)
                if (!pressedKeys.Contains(key))
                    _released.Add(key);

            _held = pressedKeys.ToList();
        }

        public static bool Pressed(Keys key) => _pressed.Contains(key);
        public static bool Down(Keys key) => _held.Contains(key);
        public static bool Released(Keys key) => _released.Contains(key);

        private static List<Keys> _pressed;
        private static List<Keys> _held;
        private static List<Keys> _released;

    }
}
