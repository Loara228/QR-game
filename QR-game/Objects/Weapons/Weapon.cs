using QR_game.Objects.Entities;
using QR_game.Objects.Interfaces;
using SharpDX;
using System;
using static Microsoft.Xna.Framework.MathHelper;

namespace QR_game.Objects.Weapons
{
    public abstract class Weapon : GameObj
    {
        public Weapon(Player owner)
        {
            this._owner = owner;
            this.Width = 35;
            this.Height = 10;
        }

        public override void Update()
        {
            base.Update();
            this.Center = _owner.Center + (_sprite.Flip ? new Vector2(-Offset.X, Offset.Y) : Offset);
        }

        public override void Draw()
        {
            base.Draw();
            QR_game.Drawing.Graphics.DrawCircle(Center + new Vector2(2, 8), 4, Microsoft.Xna.Framework.Color.Red, 3, 4);
        }

        public virtual bool CanAttack()
        {
            return Ammo > 0;
        }

        public virtual void Attack(Entity target)
        {
        }

        public void TryAttack(Entity target)
        {
            if (CheckAngle(target))
            {
                if (CanAttack())
                    Attack(target);
                // else smoke ?
            }
        }

        private bool CheckAngle(Entity target)
        {
            float angle_deg = ToDegrees(GetAngle(target));

            if (_sprite.Flip)
            {
                angle_deg += 180;
                if ((angle_deg > 270 && angle_deg < 360) || (angle_deg > 0 && angle_deg < 90))
                {
                    _sprite.Rotation = ToRadians(angle_deg);
                    return true;
                }
            }
            if (angle_deg > -90 && angle_deg < 90)
            {
                _sprite.Rotation = ToRadians(angle_deg);
                return true;
            }

            return false;
        }

        private float GetAngle(Entity target)
        {
            return (float)Math.Atan2((double)(target.Center.Y - this.Center.Y), (double)(target.Center.X - this.Center.X));
        }

        public int Ammo
        {
            get; set;
        }

        public int MaxAmmo
        {
            get; set;
        }

        public Vector2 BarrelPosition
        {
            get => throw new NotImplementedException("todo");
        }

        /// <summary>
        /// Смещение от центра персонажа для отображения оружия
        /// </summary>
        protected Vector2 Offset
        {
            get; set;
        }

        /// <summary>
        /// Смещение от нулевой координаты текстуры. Указывает дуло оружия
        /// </summary>
        protected Vector2 BarrelOffset
        {
            get; set;
        }

        protected Player _owner;
    }
}
