using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QR_game.Objects.Weapons.RangedWeapon
{
    public class Shotgun : Weapon
    {
        public Shotgun()
        {
            AttackHandler = new ShotgunAttackHandler(this);
        }
    }

    public class ShotgunAttackHandler : AttackHandler
    {
        public ShotgunAttackHandler(Weapon weapon) : base(weapon)
        {

        }

        public override bool CanAttack()
        {
            return base.CanAttack();
        }

        public override void Attack(Entity target)
        {
            base.Attack(target);
        }
    }
}
