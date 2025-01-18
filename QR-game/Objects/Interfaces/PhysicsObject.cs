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
            base.Update();
            if (!StaticObject)
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
            }


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
            if (this.Collidable && !this.StaticObject)
            {
                Game1.CurrentLevel.Objects
                    .OfType<PhysicsObject>()
                    .Where(x => x != this)
                    .ToList()
                    .ForEach(x =>
                    {
                        if (x.Collidable)
                            if (Collision.ObjObj(this, x))
                                this.Collide(x, oldPos);
                    });
            }
        }

        private void Collide(PhysicsObject with, SharpDX.Vector2 oldPos)
        {
            SharpDX.Vector2 nextPosition = this.Position;
            const float offset = 0.1001f;

            // top collision
            if (this.Rect.Bottom >= with.Position.Y && oldPos.Y + Height < with.Position.Y)
            {
                nextPosition.Y = with.Position.Y - offset - this.Height;
                if (!this.IgnoreCollision && !with.IgnoreCollision)
                    VSpeed = 0;
                this.Touch(TouchSide.Bottom, with);
                with.Touch(TouchSide.Top, this);
            }
            // bottom collision
            else if (this.Position.Y <= with.Rect.Bottom && oldPos.Y > with.Rect.Bottom)
            {
                nextPosition.Y = with.Rect.Bottom + offset;
                if (!this.IgnoreCollision && !with.IgnoreCollision)
                    VSpeed = 0;
                this.Touch(TouchSide.Top, with);
                with.Touch(TouchSide.Bottom, this);
            }
            // right collision
            else if (this.Rect.Right >= with.Position.X && oldPos.X + Width < with.Position.X)
            {
                nextPosition.X = with.Position.X - offset - Width;
                if (!this.IgnoreCollision && !with.IgnoreCollision)
                    HSpeed = 0;
                this.Touch(TouchSide.Right, with);
                with.Touch(TouchSide.Left, this);
            }
            // left collision
            else if (this.Position.X <= with.Rect.Right && oldPos.X > with.Rect.Right)
            {
                nextPosition.X = with.Rect.Right + offset;
                if (!this.IgnoreCollision && !with.IgnoreCollision)
                    HSpeed = 0;
                this.Touch(TouchSide.Left, with);
                with.Touch(TouchSide.Right, this);
            }

            if (!this.IgnoreCollision && !with.IgnoreCollision)
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

        /// <summary>
        /// Для особых объектов, которые должны взаимодействовать с объектами, но не должны сталкиваться.
        /// Или для временных действий (типо перекат сквозь врагов)
        /// </summary>
        public bool IgnoreCollision
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
