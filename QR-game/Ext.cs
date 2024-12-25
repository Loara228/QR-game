using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QR_game
{
    public static class Ext
    {
        public static Microsoft.Xna.Framework.Rectangle ToXna(this SharpDX.RectangleF rect)
        {
            return new Microsoft.Xna.Framework.Rectangle((int)rect.X, (int)rect.Y, (int)rect.Width, (int)rect.Height);
        }
    }
}
