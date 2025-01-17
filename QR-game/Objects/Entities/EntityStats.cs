﻿namespace QR_game.Objects.Entities
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

        public float moveSpeed;
    }
}
