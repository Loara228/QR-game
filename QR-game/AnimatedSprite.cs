using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using QR_game.Objects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QR_game
{
    public class AnimatedSprite
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="sourceX">X координата текстуры для первого кадра</param>
        /// <param name="sourceY">Y координата текстуры для первого кадра</param>
        /// <param name="sourceWidth">Пиксели (W) одного спрайта</param>
        /// <param name="sourceHeight">Пиксели (H) одного спрайта</param>
        /// <param name="frames">Кол-во кадров на текстуре</param>
        public AnimatedSprite(
            Texture2D texture,
            int sourceX = 0,
            int sourceY = 0,
            int sourceWidth = 32,
            int sourceHeight = 32,
            int frames = 1)
        {
            Texture = texture;
            var list = new List<Rectangle?>();
            for (int i = 0; i < frames; i++)
            {
                list.Add(new Rectangle(sourceX, sourceY + (i * sourceHeight), sourceWidth, sourceHeight));
            }
            _sourceRectangles = list.ToArray();
        }

        public AnimatedSprite(Texture2D texture, Rectangle?[] sourceRectangles)
        {
            Texture = texture;
            _sourceRectangles = sourceRectangles;
        }

        public AnimatedSprite(Texture2D texture, Rectangle? rect = null) : this(texture, [rect])
        {
        }

        public void Draw(GameObj from)
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
                    Origin = new Vector2(value.Width / 2, value.Height / 2);
            }
        }

        public Rectangle? GetSourceRect()
        {
            return _sourceRectangles[_frameIndex];
        }

        public Vector2 Origin
        {
            get; set;
        } = Vector2.Zero;

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

        public bool Flip
        {
            get; set;
        } = true;

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

        private float _depth = 1f;
        private int _frameIndex = 0;
        private Rectangle?[] _sourceRectangles;
        private Texture2D _texture;
    }
}
