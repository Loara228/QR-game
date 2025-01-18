using QR_game.Drawing;

namespace QR_game.Objects.Entities.Enemies.AI
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
