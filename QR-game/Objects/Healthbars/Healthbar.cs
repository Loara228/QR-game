using QR_game.Objects.Entities;

namespace QR_game.Objects.Healthbars
{
    public abstract class Healthbar : Interfaces.IDrawable
    {
        public Healthbar(Entity owner)
        {
            _owner = owner;
        }

        public abstract void Draw();

        protected Entity _owner;
    }
}
