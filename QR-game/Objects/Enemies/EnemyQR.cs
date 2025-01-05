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
            _sprite = new AnimatedSprite(Textures.QR, 0, 0, 40, 41, 1);
            Team = Team.Enemies;
        }
    }
}
