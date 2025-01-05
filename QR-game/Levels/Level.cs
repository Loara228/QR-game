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
            this.Add(_player = new Player(200, 200));
        }

        public void Update()
        {
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
            _objects.Add(obj);
        }

        public void Remove()
        {
            throw new NotImplementedException();
        }

        private Player _player;
        private Camera _camera;
        private List<GameObj> _objects;
        // list add, list remove
    }
}
