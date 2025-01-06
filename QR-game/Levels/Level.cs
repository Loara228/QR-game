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
            this.Add(_player = new Player(0, 0));
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
            _camera.CenterX = _player.Center.X;
            _camera.CenterY = _player.Center.Y;
            _camera.Update();
            foreach (GameObj obj in _objects)
            {
                obj.Update();
            }
        }

        public void Draw()
        {
            Graphics.spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, _camera.GetMatrix());
            foreach (GameObj obj in _objects)
            {
                obj.Draw();
            }
            Dev.Draw();
            Graphics.spriteBatch.End();
        }

        public void HitEnemyById(int id)
        {
            foreach (Entity ent in _objects.OfType<Entity>())
            {
                if (ent.Team != _player.Team && ent.ID == id)
                {
                    ent.Hit(_player);
                }
            }
        }

        public int GetNewId()
        {
            List<int> ids = new List<int>();

            _objects.OfType<Entity>().ToList().ForEach(x => ids.Add(x.ID));
            foreach (var obj in _obj2)
            {
                if (obj.Item2 && obj.Item1 is Entity)
                {
                    ids.Add((obj.Item1 as Entity).ID);
                }
            }
            for (int i = 1; i < 100; i++)
            {
                if (!ids.Contains(i))
                {
                    return i;
                }
            }
            return -1;
        }

        public void Add(GameObj obj)
        {
            if (obj is Entity)
            {
                var ent = (obj as Entity);
                if (ent.Team != QR_game.Objects.Enemies.Team.Unknown &&
                    ent.Team != QR_game.Objects.Enemies.Team.Allies)
                {
                    ent.ID = GetNewId();
                }
            }
            _obj2.Add((obj, true));
        }

        public void Remove(GameObj obj)
        {
            _obj2.Add((obj, false));
        }

        public IReadOnlyList<GameObj> Objects
        {
            get => _objects;
        }

        public Player Player
        {
            get => _player;
        }

        private Player _player;
        private Camera _camera;
        private List<GameObj> _objects;
        private List<(GameObj, bool)> _obj2;
    }
}
