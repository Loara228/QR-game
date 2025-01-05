using Microsoft.Xna.Framework.Graphics;
using QR_game.Objects;
using QR_game.Objects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QR_game.Levels
{
    public abstract class Level
    {
        public Level()
        {
            _camera = new Camera();
            _objects = new List<GameObj>();
            _obj2 = new List<(GameObj, bool)>();
            this.Add(_player = new Player(200, 200));
        }

        public void Update()
        {
            foreach(var obj in _obj2)
            {
                if (obj.Item2)
                    _objects.Add(obj.Item1);
                else
                    _objects.Remove(obj.Item1);
            }
            _obj2.Clear();
            _camera.CenterX = _player.X;
            _camera.CenterY = _player.Y;
            _camera.Update();
            foreach (GameObj obj in _objects)
            {
                obj.Update();
            }
        }

        public void Draw()
        {
            Graphics.spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, _camera.GetMatrix());
            foreach (GameObj obj in _objects)
            {
                obj.Draw();
            }
            Graphics.spriteBatch.End();
        }

        public IReadOnlyList<GameObj> Objects
        {
            get => _objects;
        }

        public void Add(GameObj obj)
        {
            _obj2.Add((obj, true));
        }

        public void Remove(GameObj obj)
        {
            _obj2.Add((obj, false));
        }

        private Player _player;
        private Camera _camera;
        private List<GameObj> _objects;
        private List<(GameObj, bool)> _obj2;
    }
}
