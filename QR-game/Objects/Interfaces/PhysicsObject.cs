﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QR_game.Objects.Interfaces
{
    public class PhysicsObject : GameObj
    {
        public PhysicsObject(float x, float y) : base(x, y)
        {

        }

        public override void Update()
        {
            if (MathF.Abs(velocity.X) < friction * 2)
            {
                velocity.X = 0;
            }
            else
            {
                velocity.X -= velocity.X > 0 ? friction : -friction;
            }
            if (MathF.Abs(velocity.Y) < friction * 2)
            {
                velocity.Y = 0;
            }
            else
            {
                velocity.Y -= velocity.Y > 0 ? friction : -friction;
            }

            UpdateLimits();

            this.X += velocity.X;
            this.Y += velocity.Y;
        }

        private void UpdateLimits()
        {
            if (velocity.X > max_speed)
            {
                velocity.X = max_speed;
            }
            else if (velocity.X < -max_speed)
            {
                velocity.X = -max_speed;
            }

            if (velocity.Y > max_speed)
            {
                velocity.Y = max_speed;
            }
            else if (velocity.Y < -max_speed)
            {
                velocity.Y = -max_speed;
            }
        }

        public Vector2 velocity = new Vector2();

        private readonly float max_speed = 6f;
        private readonly float friction = 0.35f;
    }
}