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
        public AttackHandler AttackHandler
        {
            get; set;
        }

        public void TryAttack(Entity target)
        {
            if (AttackHandler.CanAttack())
            {
                AttackHandler.Attack(target);
            }
        }

        public int Ammo
        {
            get; set;
        }

        public int MaxAmmo
        {
            get; set;
        }

        public int Damage
        {
            get; set;
        }
    }
}
