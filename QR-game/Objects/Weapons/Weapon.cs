using QR_game.Objects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            this.Center = _owner.Center;
            base.Update();
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
            if (CanAttack())
                Attack(target);
        }

        public int Ammo
        {
            get; set;
        }

        public int MaxAmmo
        {
            get; set;
        }

        protected Player _owner;
    }
}
