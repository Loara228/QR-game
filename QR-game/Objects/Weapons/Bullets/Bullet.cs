using QR_game.Objects.Interfaces;
using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QR_game.Objects.Weapons.Bullets
{
    public abstract class Bullet : PhysicsObject
    {
        public Bullet(Vector2 start, Vector2 end) : base(start.X, start.Y)
        {
            this._end = end;
            this._start = start;
            this.Width = 10;
            this.Height = 4;
            this.Range = 500f;
            this.Spread = 1f;

            this.StaticObject = false;
            this.Collidable = true;
        }

        public override void Update()
        {
            const float speed = 10f;
            this.Velocity = _dir * speed;
            // tracer
            base.Update();
        }

        protected void Fire()
        {
            this._sprite = new AnimatedSprite(Textures.GetTexture("bullet"), [null]);
            this._sprite.Rotation = (float)Math.Atan2((double)(_end.Y - _start.Y), (double)(_end.X - _start.X));
            this._dir = CalcDirection();
        }

        protected Vector2 CalcDirection()
        {
            return Vector2.Normalize(_end - _start);
        }

        protected float Range
        {
            get; set;
        }

        protected float Spread
        {
            get; set;
        }

        private Vector2 _dir;
        private Vector2 _start;
        private Vector2 _end;
    }
}
