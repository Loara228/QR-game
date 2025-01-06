using System;
using SharpDX;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QR_game.Objects.Interfaces
{
    public class PhysicsObject : GameObj
    {
        public enum TouchSide
        {
            None = 0,
            Top = -1,
            Left = -1,
            Right = 1,
            Bottom = 1
        }

        public PhysicsObject(float x, float y) : base(x, y)
        {
            Collidable = true;
            StaticObject = true;
            Velocity = new SharpDX.Vector2();
            MaxSpeed = 5.5f;
        }

        public override void Update()
        {
            if (MathF.Abs(HSpeed) < friction)
            {
                HSpeed = 0;
            }
            else
            {
                HSpeed -= HSpeed > 0 ? friction : -friction;
            }
            if (MathF.Abs(VSpeed) < friction)
            {
                VSpeed = 0;
            }
            else
            {
                VSpeed -= VSpeed > 0 ? friction : -friction;
            }

            UpdateLimits();

            var oldPos = this.Position;

            this.X += HSpeed;
            this.Y += VSpeed;

            UpdateCollision(oldPos);
        }

        protected virtual void Touch(TouchSide side, PhysicsObject from)
        {

        }

        public float Speed() => 
            MathF.Sqrt(MathF.Pow(Math.Abs(this.Velocity.X), 2) + MathF.Pow(Math.Abs(this.Velocity.Y), 2));

        private void UpdateCollision(SharpDX.Vector2 oldPos)
        {
            if (Collidable && !StaticObject)
            {
                Game1.CurrentLevel.Objects
                    .OfType<PhysicsObject>()
                    .Where(x => x != this)
                    .ToList()
                    .ForEach(x =>
                    {
                        if (Collision.ObjObj(this, x))
                            this.Collide(x, oldPos);
                    });
            }
        }

        private void Collide(PhysicsObject obj, SharpDX.Vector2 oldPos)
        {

            SharpDX.Vector2 nextPosition = this.Position;
            const float offset = 0.1001f;

            // top collision
            if (this.Rect.Bottom >= obj.Position.Y && oldPos.Y + Height < obj.Position.Y)
            {
                nextPosition.Y = obj.Position.Y - offset - this.Height;
                VSpeed = 0;
                this.Touch(TouchSide.Bottom, obj);
                obj.Touch(TouchSide.Top, this);
            }
            // bottom collision
            else if (this.Position.Y <= obj.Rect.Bottom && oldPos.Y > obj.Rect.Bottom)
            {
                nextPosition.Y = obj.Rect.Bottom + offset;
                VSpeed = 0;
                this.Touch(TouchSide.Top, obj);
                obj.Touch(TouchSide.Bottom, this);
            }
            // right collision
            else if (this.Rect.Right >= obj.Position.X && oldPos.X + Width < obj.Position.X)
            {
                nextPosition.X = obj.Position.X - offset - Width;
                HSpeed = 0;
                this.Touch(TouchSide.Right, obj);
                obj.Touch(TouchSide.Left, this);
            }
            // left collision
            else if (this.Position.X <= obj.Rect.Right && oldPos.X > obj.Rect.Right)
            {
                nextPosition.X = obj.Rect.Right + offset;
                HSpeed = 0;
                this.Touch(TouchSide.Left, obj);
                obj.Touch(TouchSide.Right, this);
            }

            this.Position = nextPosition;
        }
        private void UpdateLimits()
        {
            if (HSpeed > MaxSpeed)
            {
                HSpeed = MaxSpeed;
            }
            else if (Velocity.X < -MaxSpeed)
            {
                HSpeed = -MaxSpeed;
            }

            if (Velocity.Y > MaxSpeed)
            {
                _velocity.Y = MaxSpeed;
            }
            else if (Velocity.Y < -MaxSpeed)
            {
                _velocity.Y = -MaxSpeed;
            }
        }

        /// <summary>
        /// Объект может сталкиваться
        /// </summary>
        public bool Collidable
        {
            get; set;
        }

        /// <summary>
        /// Если false, то обрабатываем столкновения
        /// </summary>
        public bool StaticObject
        {
            get; set;
        }

        public SharpDX.Vector2 Velocity
        {
            get => _velocity;
            set => _velocity = value;
        }

        public float HSpeed
        {
            get => Velocity.X;
            set
            {
                Velocity = new SharpDX.Vector2(value, VSpeed);
            }
        }

        public float VSpeed
        {
            get => Velocity.Y;
            set
            {
                Velocity = new SharpDX.Vector2(HSpeed, value);
            }
        }

        protected float MaxSpeed
        {
            get; set;
        }

        private readonly float friction = 0.35f;

        private SharpDX.Vector2 _velocity;
    }
}
