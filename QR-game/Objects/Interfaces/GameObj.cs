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
            this.Width = 32;
            this.Height = 32;
        }

        public GameObj() : this(0, 0)
        {
        }

        public virtual void Update()
        {

        }

        public virtual void Draw()
        {
            Sprite.Draw(this);
        }

        public Vector2 Center
        {
            get => _rect.Center;
            set
            {
                this.Position = new Vector2(value.X - Width / 2, value.Y - Height / 2);
            }
        }

        public Size2F Size
        {
            get => _rect.Size;
            set => _rect.Size = value;
        }

        public RectangleF Rect
        {
            get => _rect;
            set => _rect = value;
        }

        public SharpDX.Vector2 Position
        {
            get
            {
                return new SharpDX.Vector2(X, Y);
            }
            set
            {
                _rect.X = value.X;
                _rect.Y = value.Y;
            }
        }

        public float X
        {
            get => _rect.X;
            set => _rect.X = value;
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

        public AnimatedSprite Sprite
        {
            get => _sprite;
        }

        protected AnimatedSprite _sprite;
        private RectangleF _rect;
    }
}
