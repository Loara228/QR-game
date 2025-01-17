using QR_game.Objects.Interfaces;
using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QR_game.Objects.Weapons.Bullets
{
    public class Bullet : PhysicsObject
    {
        public Bullet(Vector2 start, Vector2 end, Entity from, bool fire = true) : base(start.X, start.Y)
        {
            // Свойства пули
            this.Spread = 0.15f;
            this.Range = 1000;

            // Внешний вид
            this.Width = 10;
            this.Height = 4;
            this._sprite = new AnimatedSprite(Textures.GetTexture("bullet"), [null]);

            // Путь
            this._start = start;
            this._end = end;
            CalcDirection();
            this._end = _start + _dir * Range;

            this.StaticObject = true;
            this.Collidable = false;
            this.MaxSpeed = 9999f;

            this._owner = from;

            if (fire)
                Fire();
        }

        public override void Update()
        {
            const float speed = 60f;
            this.Velocity = _dir * speed;
            _curTrace1 = this.Center;
            base.Update();
            _curTrace2 = this.Center;

            if (Vector2.Distance(_start, _curTrace2) > this.Range)
            {
                Game1.CurrentLevel.Remove(this);
            }

            foreach (var intersection in Collision.TraceOrd<PhysicsObject>(_curTrace1, _curTrace2))
            {
                if (intersection.obj is Entity)
                {
                    var ent = intersection.obj as Entity;
                    if (ent.Team != _owner.Team)
                    {
                        ent.Hit(_owner);
                        //OnImpacted(intersection.point, intersection.obj);
                    }
                    break;
                }
                else if (intersection.obj is Block)
                {
                    OnImpacted(intersection.point, intersection.obj);
                    break;
                }
            }
        }

        protected virtual void OnImpacted(Vector2 position, GameObj obj)
        {
            // Add smoke
            _curTrace2 = position;
            Center = position;
            Game1.CurrentLevel.Remove(this);
        }

        public override void Draw()
        {
            Graphics.DrawLine(_curTrace1, _curTrace2, new Microsoft.Xna.Framework.Color(0, 0, 0, 100), 2);
            base.Draw();
        }

        public virtual void Fire()
        {
            ApplySpread();
            this._sprite.Rotation = (float)Math.Atan2((double)(_end.Y - _start.Y), (double)(_end.X - _start.X));
            Game1.CurrentLevel.Add(this);
        }

        protected virtual void ApplySpread()
        {
            _curSpread = CalcSpread();
            float ang = MathF.Atan2(_dir.Y, _dir.X) + _curSpread;
            this._dir = new Vector2(MathF.Cos(ang), MathF.Sin(ang));
            this._end = _start + _dir * Range;

            CalcDirection();
        }

        protected virtual float CalcSpread()
        {
            return Random.Shared.NextFloat(-(Spread / 2f), Spread / 2f);
        }

        private void CalcDirection()
        {
            _dir = Vector2.Normalize(_end - _start);
        }

        protected float Range
        {
            get; set;
        }

        protected float Spread
        {
            get; set;
        }

        protected Vector2 _start;
        protected Vector2 _end;

        private float _curSpread;
        private Vector2 _dir;
        private Vector2 _curTrace1, _curTrace2;

        private Entity _owner;
    }
}
