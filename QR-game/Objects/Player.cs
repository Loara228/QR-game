﻿using Microsoft.Xna.Framework.Input;
using QR_game.Objects.Interfaces;
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
            _sprite = new AnimatedSprite(Textures.GetTexture("player"), 0, 0, 32, 64, 1);
            _controller = new Controller();
            Width = 64;
            Height = 128;
            Team = Enemies.Team.Allies;

            Stats.damage = 80;
            Stats.magicResist = 25;
            Stats.armor = 5;
            Stats.pickupRadius = 150;
            Stats.moveSpeed = 6f;

            this.MaxSpeed = Stats.moveSpeed;
        }

        public override void Draw()
        {
            base.Draw();
        }

        public override void Update()
        {
            _controller.Update(this);
            if (Keyboard.Pressed(Keys.D))
                _sprite.Flip = false;
            else if (Keyboard.Pressed(Keys.A))
                _sprite.Flip = true;
            base.Update();
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

        protected override void OnDamage(int value)
        {
            base.OnDamage(value);
        }

        private Controller _controller;
    }
}
