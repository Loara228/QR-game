using QR_game.Objects.Interfaces;
using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QR_game
{
    internal static class Collision
    {
        public static bool ObjObj(PhysicsObject obj1, PhysicsObject obj2)
        {
            return obj1.Rect.Right >= obj2.X &&
                    obj1.X <= obj2.Rect.Right &&
                    obj1.Rect.Bottom >= obj2.Y &&
                    obj1.Y <= obj2.Rect.Bottom;
        }

        public static bool CircleObj(Vector2 center, float radius, PhysicsObject obj)
        {
            // temporary variables to set edges for testing
            float testX = center.X;
            float testY = center.Y;

            if (center.X < obj.X) testX = obj.X;  // test left edge
            else if (center.X > obj.Rect.Right) testX = obj.Rect.Right;   // right edge
            if (center.Y < obj.Y) testY = obj.Y;  // top edge
            else if (center.Y > obj.Rect.Bottom) testY = obj.Rect.Bottom; // bottom edge

            float distX = center.X - testX;
            float distY = center.Y - testY;
            float distance = (float)Math.Sqrt((distX * distX) + (distY * distY));

            // if the distance is less than the radius, collision!
            return distance <= radius;
        }



        public static bool CircleCircle(Vector2 c1, float radius1, Vector2 c2, float radius2)
        {
            float distX = c1.X - c2.X;
            float distY = c1.Y - c2.Y;
            float distance = MathF.Sqrt((distX * distX) + (distY * distY));

            return distance <= radius1 + radius2;
        }
    }
}
