using QR_game.Objects.Entities;
using QR_game.Objects.Interfaces;
using SharpDX;
using System;

namespace QR_game.Objects.Weapons
{
    public abstract class Weapon : GameObj
    {
        public Weapon(Player owner)
        {
            this._owner = owner;
        }

        public override void Update()
        {
            base.Update();
            this.Center = _owner.Center + (_sprite.Flip ? new Vector2(-Offset.X, Offset.Y) : Offset);
        }

        public override void Draw()
        {
            base.Draw();
        }

        public virtual bool CanAttack()
        {
            return Ammo > 0;
        }

        public virtual void Attack(Entity target)
        {

        }

        public virtual void TryAttack(Entity target)
        {
        }

        public int Ammo
        {
            get; set;
        }

        public int MaxAmmo
        {
            get; set;
        }

        /// <summary>
        /// Смещение от центра персонажа для отображения оружия
        /// </summary>
        protected Vector2 Offset
        {
            get; set;
        }

        protected Player _owner;
    }
}
