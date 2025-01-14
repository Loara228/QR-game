﻿using Microsoft.Xna.Framework.Content;
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
            QR = new Dictionary<int, Texture2D>();
            _textures = new Dictionary<string, Texture2D>();

            for (int i = 1; i < 100; i++)
            {
                QR.Add(i, content.Load<Texture2D>($"qr/qr{i.ToString("00")}"));
            }

            _null = content.Load<Texture2D>("null");
            LoadTexture("test", content);
            LoadTexture("player", content);
        }

        private static void LoadTexture(string name, ContentManager content)
        {
            _textures.Add(name, content.Load<Texture2D>(name));
        }

        public static Texture2D GetTexture(string name)
        {
            if (_textures.TryGetValue(name, out Texture2D tex))
            {
                return tex;
            }
            return _null;
        }

        public static Dictionary<int, Texture2D> QR;
        private static Dictionary<string, Texture2D> _textures;
        private static Texture2D _null = null;
    }
}
