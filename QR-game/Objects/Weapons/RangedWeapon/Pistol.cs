﻿using QR_game.Levels;
using QR_game.Objects.Drop;
using QR_game.Objects.Weapons.Bullets;
using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QR_game.Objects.Weapons.RangedWeapon
{
    public class Pistol : Weapon
    {
        public Pistol(Player owner) : base(owner)
        {
            Ammo = 16;
            MaxAmmo = 16;
        }

        public override void Update()
        {
            base.Update();
        }

        public override void Draw()
        {
            base.Draw();
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