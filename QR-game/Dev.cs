using QR_game.Levels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using static QR_game.Ext;
using QR_game.Objects;
using Microsoft.Xna.Framework.Input;

namespace QR_game
{
    internal static class Dev
    {
        public static void Update()
        {
            if (Keyboard.Pressed(Keys.Escape))
                Game1.CurrentLevel = new TestLevel();
        }
        
        public static void Draw()
        {
            //DrawHitboxes();
            //DrawAI();
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
