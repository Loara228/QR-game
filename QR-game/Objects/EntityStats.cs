using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QR_game.Objects
{
    public class EntityStats
    {
        public EntityStats()
        {

        }

        public static EntityStats Default() =>
            new EntityStats()
            {
                health = 500,
                maxHealth = 500,
                damage = 55,
                armor = 0,
                magicResist = 0,
                experience = 0,
                pickupRadius = 0,
                moveSpeed = 5.5f
            };

        // on something changed? Calc all from list
        // props

        public int damage;

        public int health;
        public int maxHealth;

        public int armor;
        public int magicResist;

        public int experience;

        public int pickupRadius;

        public float moveSpeed;
    }
}
