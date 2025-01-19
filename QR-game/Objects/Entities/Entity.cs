using QR_game.Drawing;
using QR_game.Objects.Entities.Enemies.AI;
using QR_game.Objects.Healthbars;

namespace QR_game.Objects.Entities
{
    public class Entity : PhysicsObject
    {
        public Entity(float x, float y) : base(x, y)
        {
            _healthbar = new HealthbarEntity(this);

            Width = 32;
            Height = 32;
            Collidable = true;
            StaticObject = false;
            Team = Team.Unknown;

            Stats = EntityStats.Default();

            this._id = -1;
            this._ai = null!;
        }

        public override void Draw()
        {
            base.Draw();
            _healthbar.Draw();
        }

        public override void Update()
        {
            _ai?.Update();
            base.Update();
        }

        public void Hit(Entity from)
        {
            OnDamage(from.Damage);
        }

        protected virtual void OnDamage(int value)
        {
            if (Health - value > 0)
            {
                Health -= value;
                _ai?.OnDamaged();
            }
            else
            {
                Health = 0;
                OnKilled();
            }
        }

        protected virtual void OnHeal(int value)
        {
            if (Health + value > MaxHealth)
            {
                Health = MaxHealth;
            }
            else
            {
                Health += value;
            }
        }

        protected virtual void OnKilled()
        {
            Game1.CurrentLevel.Remove(this);
        }

        protected override void Touch(TouchSide side, PhysicsObject from)
        {
        }

        public int ID
        {
            get => _id;
            set
            {
                _id = value;
                if (Team != Team.Unknown && Team != Team.Allies)
                    _sprite.Texture = Textures.QR[_id];
            }
        }

        public bool HasAI
        {
            get => _ai != null;
        }

        public int Health
        {
            get => Stats.health;
            set => Stats.health = value;
        }

        public int MaxHealth
        {
            get => Stats.maxHealth;
        }

        public int Damage
        {
            get => Stats.damage;
        }

        public Team Team
        {
            get; set;
        }

        public AI AI
        {
            get => _ai;
        }

        public EntityStats Stats
        {
            get; set;
        }

        protected AI _ai;
        protected Healthbar _healthbar;

        private int _id;
    }
}
