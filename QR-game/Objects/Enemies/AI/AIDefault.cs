using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QR_game.Objects.Enemies.AI
{
    /// <summary>
    /// Всё просто. Если подошел, то атакуем. Что-то типо простого слизня
    /// </summary>
    public class AIDefault : AI
    {
        public AIDefault(Entity owner) : base(owner)
        {
            CurrentState = AIState.Chasing;
            _idleTimerMax = 8f;
            AttackCooldownTime = 6f;
        }

        public virtual void Attack()
        {
            var vel = new Vector2(_attackPosition.X - _owner.X, _attackPosition.Y - _owner.Y);
            vel.Normalize();
            _owner.Velocity = vel * 15f;
        }

        protected override void Attacking()
        {
            if (AttackChargeTimer <= 0)
            {
                CurrentState = AIState.Idle;
                _idleTimer = _idleTimerMax;
                AttackCooldown = 0f;
                Attack();
                return;
            }
            AttackChargeTimer -= 0.01f;
        }

        public override void OnDamaged()
        {
            base.OnDamaged();
            CurrentState = AIState.Idle;
            _idleTimer = _idleTimerMax;
            AttackCooldown = 0f;
        }

        protected override void Finding()
        {
        }

        protected override void Chasing()
        {
            AttackCooldown = AttackCooldownTime;
            Player target = Game1.CurrentLevel.Player;
            if (Collision.CircleObj(_owner.Center, AttackRange, target))
            {
                CurrentState = AIState.Attacking;
                AttackChargeTimer = _attackChargeTimerMax;
                _attackPosition = target.Center;
            }
            else
            {
                var vel = new Vector2(target.X - _owner.X, target.Y - _owner.Y);
                vel.Normalize();
                _owner.Velocity = vel * 3f;
            }
        }

        protected override void Idle()
        {
            if (_idleTimer < 0 && MathF.Abs(_owner.HSpeed) < 0.1f && MathF.Abs(_owner.VSpeed) < 0.1f)
            {
                CurrentState = AIState.Chasing;
                return;
            }
            _idleTimer -= 0.1f;
        }

        protected float AttackChargeTimer
        {
            get; set;
        }

        private Vector2 _attackPosition = Vector2.Zero;
        protected float _attackCdTimerMax, _attackChargeTimerMax;
        protected float _idleTimer, _idleTimerMax;
    }
}
