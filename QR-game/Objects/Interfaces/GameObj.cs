using Microsoft.Xna.Framework.Graphics;
using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QR_game.Objects.Interfaces
{
    public abstract class GameObj : IDrawable, IUpdatable
    {
        public GameObj(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }

        public virtual void Update()
        {
        }

        public virtual void Draw()
        {
            Graphics.spriteBatch.Draw(_texture, new Microsoft.Xna.Framework.Vector2(X, Y), Microsoft.Xna.Framework.Color.White);
        }

        public RectangleF Rect
        {
            get => _rect;
            set => _rect = value;
        }

        public float X
        {
            get => _rect.X;
            set => _rect.Y = value;
        }

        public float Y
        {
            get => _rect.Y;
            set => _rect.Y = value;
        }

        public float Width
        {
            get => _rect.Width;
            set => _rect.Width = value;
        }

        public float Height
        {
            get => _rect.Height;
            set => _rect.Height = value;
        }

        public Texture2D Texture
        {
            get => _texture;
        }

        protected Texture2D _texture;
        private RectangleF _rect;
    }
}
