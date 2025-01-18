using QR_game.Drawing;

namespace QR_game.Objects.Blocks
{
    public class Block : PhysicsObject
    {
        public Block(float x, float y) : base(x, y)
        {
            _sprite = new AnimatedSprite(Textures.GetTexture("null"), [null]);
            Width = 32;
            Height = 32;
            Collidable = true;
        }

        public override void Draw()
        {
            base.Draw();
        }

        public override void Update()
        {
            base.Update();
        }
    }
}
