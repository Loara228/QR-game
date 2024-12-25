using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QR_game
{
    public static class Graphics
    {
        static Graphics()
        {
        }

        internal static void Initialize()
        {
            _p = new Texture2D(deviceManager.GraphicsDevice, 1, 1);
            _p.SetData<Color>(new Color[] { Color.White });
        }

        public static void Draw(Texture2D texture, SharpDX.RectangleF rect, Rectangle sourceRect, Color color)
        {
            Graphics.Draw(
                texture,
                rect.ToXna(),
                sourceRect,
                color);
        }

        public static void Draw(Texture2D texture, Rectangle rect, Rectangle sourceRect, Color color)
        {
            //White = new Color(uint.MaxValue);
            Graphics.spriteBatch.Draw(
                texture,
                rect,
                sourceRect,
                color);
        }

        public static void FillRectangle(Rectangle rect, Color color)
        {
            spriteBatch.Draw(_p, rect, color);
        }

        public static float Width
        {
            get => deviceManager.GraphicsDevice.Viewport.Width;
        }

        public static float Height
        {
            get => deviceManager.GraphicsDevice.Viewport.Height;
        }

        internal static GraphicsDeviceManager deviceManager;
        internal static SpriteBatch spriteBatch;

        private static Texture2D _p;
    }
}
