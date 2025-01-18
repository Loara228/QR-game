using QR_game.Drawing;
using QR_game.Objects.Drop;
using QR_game.Objects.Enemies.AI;
using QR_game.Objects.Interfaces;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QR_game.Objects.Enemies
{
    public class EnemyQR : Entity
    {
        public EnemyQR(float x, float y) : base(x, y)
        {
            _sprite = new AnimatedSprite(null, [null], 21, 21);
            Team = Team.Enemies;
            _ai = new AIDefault(this);
            MaxSpeed = 20f;
            Width = 64;
            Height = 64;

            //Stats.health = 50;
        }

        public override void Update()
        {
            base.Update();
            _sprite.Rotation += 0.1f;
        }

        public override void Draw()
        {
            base.Draw();
        }

        protected override void OnKilled()
        {
            Game1.CurrentLevel.Add(new Drop.Drop(this.X, this.Y));
            base.OnKilled();
        }
    }
}
