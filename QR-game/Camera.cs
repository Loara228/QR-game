using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using QR_game.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QR_game
{
    public class Camera
    {
        public Camera()
        {
            _position = Vector2.Zero;
        }

        public void Update()
        {
            if (Keyboard.Down(Microsoft.Xna.Framework.Input.Keys.OemPlus))
            {
                if (Scale < 0.99)
                    Scale += 0.01f;
            }
            if (Keyboard.Down(Microsoft.Xna.Framework.Input.Keys.OemMinus))
            {
                if (Scale > 0.5)
                    Scale -= 0.01f;
            }
        }

        public Matrix GetMatrix()
        {
            return Matrix.CreateTranslation(new Vector3(-_position.X, -_position.Y, 0f)) * Matrix.CreateScale(Scale);
        }

        public float CenterX
        {
            get => X + Width / 2;
            set => _position.X = value - Width / 2;
        }

        public float CenterY
        {
            get => Y + Height / 2;
            set => _position.Y = value - Height / 2;
        }

        public float Width
        {
            get => Graphics.Width / Scale;
        }

        public float Height
        {
            get => Graphics.Height / Scale;
        }

        public float Scale
        {
            get; set;
        } = 1;

        public float X
        {
            get => _position.X;
            set => _position.X = value;
        }

        public float Y
        {
            get => _position.Y;
            set => _position.Y = value;
        }

        private Vector2 _position;
    }
}
