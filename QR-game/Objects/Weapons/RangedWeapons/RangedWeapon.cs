using QR_game.Objects.Entities;
using SharpDX;
using System;
using static Microsoft.Xna.Framework.MathHelper;

namespace QR_game.Objects.Weapons.RangedWeapons
{
    public abstract class RangedWeapon : Weapon
    {
        public RangedWeapon(Player owner) : base(owner)
        {
            this.Width = 35;
            this.Height = 10;
        }

        public override void Update()
        {
            base.Update();
        }

        public override void Draw()
        {
            base.Draw();
            //QR_game.Drawing.Graphics.DrawRect(Rect, Microsoft.Xna.Framework.Color.Red, 1);
            //QR_game.Drawing.Graphics.DrawCircle(BarrelPosition, 4, Microsoft.Xna.Framework.Color.Red, 3, 4);
        }

        public override void TryAttack(Entity target)
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

        private Vector2 Rotate(Vector2 offset, float angle, Vector2 pivot = new Vector2())
        {
            float cosRadians = (float)Math.Cos((double)angle);
            float sinRadians = (float)Math.Sin((double)angle);
            Vector2 translatedPoint = Vector2.Zero;
            translatedPoint.X = offset.X - pivot.X;
            translatedPoint.Y = offset.Y - pivot.Y;
            return new Vector2
            (
                translatedPoint.X * cosRadians - translatedPoint.Y * sinRadians + pivot.Y,
                translatedPoint.X * sinRadians + translatedPoint.Y * cosRadians + pivot.Y
            );
        }

        public Vector2 BarrelPosition
        {
            get
            {
                Vector2 offset = Vector2.Zero;
                if (_sprite.Flip)
                {
                    offset = new Vector2(-BarrelOffset.X, BarrelOffset.Y);
                }
                else
                {
                    offset = BarrelOffset;
                }
                var position = new Vector2(Center.X, Rect.Top);
                return position + Rotate(offset, _sprite.Rotation);
            }
        }

        /// <summary>
        /// Смещение от нулевой координаты текстуры. Указывает дуло оружия
        /// </summary>
        protected Vector2 BarrelOffset
        {
            get; set;
        }
    }
}
