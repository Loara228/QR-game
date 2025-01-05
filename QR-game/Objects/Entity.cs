using Microsoft.Xna.Framework;
using QR_game.Objects.Enemies;
using QR_game.Objects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QR_game.Objects
{
    public class Entity : PhysicsObject
    {
        public Entity(float x, float y) : base(x, y)
        {
            Width = 64;
            Height = 64;
            Collidable = true;
            StaticObject = false;
            Team = Team.Unknown;

            MaxHealth = 500;
            _health = MaxHealth;

            Damage = 5;
            ID = 1;
        }

        public void Hit(Entity from, int value)
        {
            var vel = new Vector2(this.X - from.X, this.Y - from.Y);
            vel.Normalize();
            this.Velocity = vel * 10f;
            OnDamage(from.Damage);
        }

        protected virtual void OnDamage(int value)
        {
            if (_health - value > 0)
            {
                _health -= value;
            }
            else
            {
                _health = 0;
                OnKilled();
            }
        }

        protected virtual void OnHeal(int value)
        {
            if (_health + value > MaxHealth)
            {
                _health = MaxHealth;
            }
            else
            {
                _health += value;
            }
        }

        protected virtual void OnKilled()
        {
            Game1.CurrentLevel.Remove(this);
        }

        protected override void Touch(TouchSide side, PhysicsObject from)
        {
            if (from is Entity && (from as Entity).Team != this.Team)
            {
                this.OnDamage((from as Entity).Damage);
            }
        }

        public int ID
        {
            get; set;
        }

        public int Health
        {
            get => _health;
        }

        public int MaxHealth
        {
            get; set;
        }

        public int Damage
        {
            get; set;
        }

        public Team Team
        {
            get; set;
        }

        private int _health;
    }
}
