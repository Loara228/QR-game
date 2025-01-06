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
            _texture = texture;
            var list = new List<Rectangle?>();
            for (int i = 0; i < frames; i++)
            {
                list.Add(new Rectangle(sourceX, sourceY + (i * sourceHeight), sourceWidth, sourceHeight));
            }
            _sourceRectangles = list.ToArray();
        }

        public AnimatedSprite(Texture2D texture, Rectangle?[] sourceRectangles)
        {
            _texture = texture;
            _sourceRectangles = sourceRectangles;
        }

        public AnimatedSprite(Texture2D texture, Rectangle? rect = null) : this(texture, [rect])
        {
        }

        public void Draw(GameObj from)
        {
            Graphics.Draw(
                _texture,
                from.Rect.ToXna(),
                _sourceRectangles[_frameIndex],
                Color.White,
                0,
                Flip);
        }

        public Texture2D Texture
        {
            get => _texture;
            set => _texture = value;
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

        public bool Flip
        {
            get; set;
        } = true;

        private int _frameIndex = 0;
        private Rectangle?[] _sourceRectangles;
        private Texture2D _texture;
    }
}
