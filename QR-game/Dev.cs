using QR_game.Levels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using static QR_game.Ext;

namespace QR_game
{
    internal static class Dev
    {
        public static void Update()
        {

        }
        
        public static void Draw()
        {
            foreach(var obj in Game1.CurrentLevel.Objects)
            {
                Graphics.FillRectangle(obj.Rect.ToXna(), Color.Red);
            }
        }

        private static readonly bool DRAW_HITBOXES = true;
    }
}
