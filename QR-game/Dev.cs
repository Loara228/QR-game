using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using QR_game.Drawing;
using QR_game.Levels;
using QR_game.Objects.Entities;
using System.Linq;

namespace QR_game
{
    internal static class Dev
    {
        public static void Update()
        {
            if (Keyboard.Pressed(Keys.Escape))
            {
                Game1.Paused = false;
                Game1.CurrentLevel = new TestLevel();
            }
            if (Keyboard.Pressed(Keys.F10))
            {
                Graphics.FullScreen = !Graphics.FullScreen;
            }
        }
        
        public static void Draw()
        {
            //DrawHitboxes();
            //DrawAI();
            Graphics.DrawText("hello world", new Vector2(10, 10), Color.Red);
        }

        public static void DrawHitboxes()
        {
            foreach (var obj in Game1.CurrentLevel.Objects)
            {
                Graphics.DrawRect(obj.Rect.ToXna(), Color.Red, 2);
                Graphics.DrawLine(
                    new Vector2(obj.Rect.X, obj.Rect.Y),
                    new Vector2(obj.Rect.BottomRight.X,
                    obj.Rect.BottomRight.Y),
                    Color.Red,
                    2);
            }
        }

        public static void DrawAI()
        {
            foreach(Entity ent in Game1.CurrentLevel.Objects.OfType<Entity>())
            {
                if (ent.HasAI)
                {
                    Graphics.DrawCircle(ent.Center, ent.AI.AttackRange, Color.Cyan);
                }
            }
        }
    }
}
