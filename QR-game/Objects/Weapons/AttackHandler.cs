using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QR_game.Objects.Weapons
{
    public abstract class AttackHandler
    {
        public AttackHandler(Weapon weapon)
        {
            this._weapon = weapon;
        }

        /// <summary>
        /// Проверка на пули и кд атаки
        /// </summary>
        /// <returns>Возможожность атаковать на данный момент</returns>
        public virtual bool CanAttack()
        {
            return _weapon.Ammo > 0;
        }

        public virtual void Attack(Entity target)
        {

        }

        private Weapon _weapon;
    }
}
