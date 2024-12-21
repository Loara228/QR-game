using Microsoft.Xna.Framework.Graphics;
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
            _objects = new List<GameObj>();
        }

        public void Update()
        {
            foreach (GameObj obj in _objects)
            {
                obj.Update();
            }
        }

        public void Draw()
        {
            foreach (GameObj obj in _objects)
            {
                obj.Draw();
            }
        }

        public IReadOnlyList<GameObj> Objects
        {
            get => _objects;
        }

        public void AddObject(GameObj obj)
        {
            _objects.Add(obj);
        }

        public void RemoveObject()
        {
            throw new NotImplementedException();
        }

        private List<GameObj> _objects;
        // list add, list remove
    }
}
