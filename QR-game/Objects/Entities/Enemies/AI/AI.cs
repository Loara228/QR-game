namespace QR_game.Objects.Entities.Enemies.AI
{
    public abstract class AI
    {

        public AI(Entity owner)
        {
            this._owner = owner;

            CurrentState = AIState.Idle;
            AttackRange = 200f;
            AttackCooldownTime = 1.2f;
            AttackCooldown = AttackCooldownTime;
        }

        public virtual void Update()
        {
            if (AttackCooldown >= 0)
                AttackCooldown -= 0.01f;

            if (CurrentState == AIState.Idle)
                Idle();
            else if (CurrentState == AIState.Finding)
                Finding();
            else if (CurrentState == AIState.Attacking)
                Attacking();
            else if (CurrentState == AIState.Chasing)
                Chasing();
        }

        public virtual void OnDamaged()
        {

        }

        protected abstract void Idle();
        protected abstract void Finding();
        protected abstract void Attacking();
        protected abstract void Chasing();

        public AIState CurrentState
        {
            get; set;
        }

        public float AttackRange
        {
            get; set;
        }

        public float AttackCooldownTime
        {
            get; set;
        }

        /// <summary>
        /// Если 0 или меньше, то урон проходит и присваивается КД от AttackCooldownTime
        /// </summary>
        public float AttackCooldown
        {
            get; set;
        }

        protected Entity _owner;
    }

    public enum AIState
    {
        Idle,
        Finding,
        Chasing,
        Attacking
    }
}
