using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using QR_game.Objects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QR_game.Drawing
{
    public class Sprite
    {
        public Sprite(Texture2D texture, int frameWidth = 32, int frameHeight = 32)
        {
            _frameWidth = frameWidth;
            _frameHeight = frameHeight;

            Texture = texture;
            var list = new List<Rectangle?>();
            for (int y = 0; y < texture.Height / frameHeight; y += 1)
            {
                for (int x = 0; x < texture.Width / frameWidth; x += 1)
                {
                    list.Add(new Rectangle(x * frameWidth, y * frameHeight, frameWidth, frameHeight));
                }
            }
            _sourceRectangles = list.ToArray();
        }

        public Sprite(Texture2D texture, Rectangle?[] sourceRectangles, int frameWidth, int frameHeight)
        {
            _sourceRectangles = sourceRectangles;
            if (frameWidth == -1 || frameHeight == -1)
            {
                if (texture != null)
                {
                    _frameWidth = texture.Width;
                    _frameHeight = texture.Height;
                    Texture = texture;
                }
                else
                {
                    throw new ArgumentNullException(nameof(texture));
                }
            }
            else
            {
                _frameWidth = frameWidth;
                _frameHeight = frameHeight;
                Texture = texture;
            }
        }

        public Sprite(Texture2D texture, Rectangle?[] sourceRectangles) : this(texture, sourceRectangles, -1, -1)
        {
        }

        public virtual void Update()
        {

        }

        public virtual void Draw(GameObj from)
        {
            if (_texture == null)
                return;

            Graphics.Draw(this, from.Rect.ToXna());
        }

        public Texture2D Texture
        {
            get => _texture;
            set
            {
                _texture = value;
                if (value != null)
                    Origin = new Vector2(_frameWidth / 2, _frameHeight / 2);
            }
        }

        public Rectangle? GetSourceRect()
        {
            return _sourceRectangles[_frameIndex];
        }

        public Vector2 Origin
        {
            get
            {
                return _origin;
            }
            set => _origin = value;
        }

        /// <summary>
        /// Кадр по счету, а не индексу
        /// </summary>
        public int Frame
        {
            get => _frameIndex + 1;
            set
            {
                _frameIndex = value - 1;
            }
        }

        public Vector2 FrameSize
        {
            get => new Vector2(_frameWidth, _frameHeight);
        }

        public bool Flip
        {
            get; set;
        } = false;

        /// <summary>
        /// Radians
        /// </summary>
        public float Rotation
        {
            get; set;
        } = 0f;

        public float Depth
        {
            get => _depth;
            set => _depth = value;
        }

        protected readonly int _frameWidth = 0;
        protected readonly int _frameHeight = 0;

        private Vector2 _origin;
        private float _depth = 1f;
        protected int _frameIndex = 0;
        protected Rectangle?[] _sourceRectangles;
        protected Texture2D _texture;
    }
}
