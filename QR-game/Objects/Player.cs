using Microsoft.Xna.Framework.Input;
using QR_game.Drawing;
using QR_game.Objects.Interfaces;
using QR_game.Objects.Weapons;
using QR_game.Objects.Weapons.RangedWeapon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QR_game.Objects
{
    public class Player : Entity
    {
        public Player(float x, float y) : base(x, y)
        {
            _sprite = new AnimatedSprite(
                Textures.GetTexture("characher"), 
                16, 
                24,
                new Dictionary<string, List<int>>()
                {
                    { "idle", new List<int>() { 0, 0, 1, 1, 0, 0, 1, 1, 0, 0, 1, 1, 0, 3, 0, 1, 1 } },
                    { "run", new List<int>() { 4, 5, 6, 7, 7 } },
                });
            _sprite.TimerDuration = 0.2f;
            _sprite.SetAnimation("idle");
            _controller = new Controller();
            Weapon = new Pistol(this);
            Width = 64;
            Height = 96;
            Team = Enemies.Team.Allies;

            Stats.damage = 80;
            Stats.magicResist = 25;
            Stats.armor = 5;
            Stats.moveSpeed = 6f;

            this.MaxSpeed = Stats.moveSpeed;
        }

        public override void Draw()
        {
            base.Draw();
            Weapon?.Draw();
        }

        public override void Update()
        {
            _controller.Update(this);
            _sprite.SetAnimation((_controller.AnyKey ? "run" : "idle"));
            _sprite.Flip = _controller.Flip;
            Weapon.Sprite.Flip = _sprite.Flip;
            base.Update();
            Weapon?.Update();
        }

        protected override void Touch(TouchSide side, PhysicsObject from)
        {
            if (from is Entity)
            {
                var ent_from = from as Entity;
                if (ent_from.Team != this.Team)
                {
                    if (ent_from.HasAI && ent_from.AI.AttackCooldown <= 0)
                    {
                        ent_from.AI.AttackCooldown = ent_from.AI.AttackCooldownTime;
                        this.OnDamage(ent_from.Damage);
                    }
                }
            }
        }

        public void Attack(Entity enemy)
        {
            Weapon?.TryAttack(enemy);
        }

        protected override void OnDamage(int value)
        {
            base.OnDamage(value);
        }

        protected override void OnKilled()
        {
            base.OnKilled();
            Game1.Paused = true;
        }

        public Weapon Weapon
        {
            get; set;
        }

        private Controller _controller;
    }
}
