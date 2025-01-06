using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
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

        internal static void Load(ContentManager content)
        {
            //_font = content.Load<SpriteFont>("arial");
        }

        internal static void Initialize()
        {
            _pixel = new Texture2D(deviceManager.GraphicsDevice, 1, 1);
            _pixel.SetData<Color>(new Color[] { Color.White });
        }

        public static void Draw(Texture2D texture, Rectangle rect, Rectangle? sourceRect, Color color, float rotationRad = 0, bool flip = false)
        {
            //White = new Color(uint.MaxValue);
            if (rotationRad == 0)
            {
                Graphics.spriteBatch.Draw(
                    texture,
                    rect,
                    sourceRect,
                    color,
                    MathHelper.ToRadians(rotationRad),
                    Vector2.Zero,
                    flip ? SpriteEffects.FlipHorizontally : SpriteEffects.None,
                    1f);
                return;
            }
            rect.X += rect.Width / 2;
            rect.Y += rect.Height / 2;
            Graphics.spriteBatch.Draw(
                texture,
                rect,
                sourceRect,
                color,
                MathHelper.ToRadians(rotationRad),
                new Vector2(rect.Width / 2, rect.Height / 2),
                flip ? SpriteEffects.FlipHorizontally : SpriteEffects.None,
                1f);
        }

        public static void DrawLine(Vector2 start, Vector2 end, Color color, float width = 1f)
        {
            Graphics.spriteBatch.Draw(
                Graphics._pixel,
                start,
                null, // auto
                color,
                (float)Math.Atan2((double)(end.Y - start.Y), (double)(end.X - start.X)),
                new Vector2(0, 0.5f),
                new Vector2((start - end).Length(), width),
                SpriteEffects.None,
                1f);
        }
        public static void DrawCircle(Vector2 center, float radius, Color col, float width = 1f, int iterations = 32)
        {
            Vector2 prev = Vector2.Zero;
            for (int i = 0; i < iterations; i++)
            {
                float ang = MathHelper.ToRadians(360f / (iterations - 1) * i);
                Vector2 cur = new Vector2((float)Math.Cos((double)ang) * radius, -(float)Math.Sin((double)ang) * radius);
                if (i > 0)
                    Graphics.DrawLine(center + cur, center + prev, col, width);
                prev = cur;
            }
        }

        public static void DrawText(string text, Vector2 position, Color color)
        {
            throw new NotImplementedException();
            //spriteBatch.DrawString(_font, text, position, color);
        }

        public static void DrawRect(SharpDX.RectangleF rect, Color color, float width = 1f)
        {
            DrawRect(rect.ToXna(), color, width);
        }

        public static void DrawRect(Rectangle rect, Color color, float width = 1f)
        {
            DrawLine(new Vector2(rect.Left, rect.Top), new Vector2(rect.Right, rect.Top), color, width);
            DrawLine(new Vector2(rect.Right, rect.Top), new Vector2(rect.Right, rect.Bottom), color, width);
            DrawLine(new Vector2(rect.Right, rect.Bottom), new Vector2(rect.Left, rect.Bottom), color, width);
            DrawLine(new Vector2(rect.Left, rect.Bottom), new Vector2(rect.Left, rect.Top), color, width);
        }

        public static void DrawCircle(SharpDX.Vector2 center, float radius, Color color, int width = 1, int segments = 16)
        {
            float segmentAngle = MathHelper.TwoPi / segments;
            Vector2 previousPoint = Vector2.Zero;

            for (int i = 0; i <= segments; i++)
            {
                float angle = i * segmentAngle;
                var currentPoint = new Vector2(
                    center.X + radius * (float)Math.Cos(angle),
                    center.Y + radius * (float)Math.Sin(angle));
                if (i > 0)
                    Graphics.DrawLine(previousPoint, currentPoint, color, width);
                previousPoint = currentPoint;
            }
        }

        public static void FillRectangle(Rectangle rect, Color color)
        {
            spriteBatch.Draw(_pixel, rect, color);
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

        private static Texture2D _pixel;
        private static SpriteFont _font;
    }
}
