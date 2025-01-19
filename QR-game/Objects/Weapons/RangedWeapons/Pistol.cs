using QR_game.Objects.Entities;
using QR_game.Objects.Weapons.Bullets;
using QR_game.Objects.Weapons.RangedWeapons;
using SharpDX;

namespace QR_game.Objects.Weapons.RangedWeapons
{
    public class Pistol : RangedWeapon
    {
        public Pistol(Player owner) : base(owner)
        {
            Ammo = 16;
            MaxAmmo = 16;

            this.Width = 32;
            this.Height = 16;
            this.Offset = new Vector2(6, 8);
            this.BarrelOffset = new Vector2(16, 2);

            _sprite = new Drawing.AnimatedSprite(Textures.GetTexture("weapons/pistol"), [null]);
            _sprite.Origin = new Microsoft.Xna.Framework.Vector2(3, 4);
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
            new Bullet(BarrelPosition, target.Center, Game1.CurrentLevel.Player);
            base.Attack(target);
        }
    }
}
