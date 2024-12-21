using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QR_game
{
    public static class Textures
    {
        internal static void Load(ContentManager content)
        {
            Textures._test = content.Load<Texture2D>("test");
        }

        public static Texture2D Test => _test;
        private static Texture2D _test = null!;
    }
}
