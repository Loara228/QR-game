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

        #region world

        public static IEnumerable<T> GetObjects<T>() where T : GameObj =>
            Game1.CurrentLevel.Objects.OfType<T>();

        public static IEnumerable<T> Trace<T>(Vector2 start, Vector2 end) where T : GameObj
        {
            var result = new List<T();
            foreach (var obj in GetObjects<T>())
            {
                if (LineObj(start, end, obj))
                {
                    result.Add(obj);
                }
            }
            return result.Cast<T>();
        }

        public static bool LineLine(Vector2 start1, Vector2 end1, Vector2 start2, Vector2 end2)
        {
            // calculate the direction of the lines
            float uA = ((end2.X - start2.X) * (start1.Y - start2.Y) - (end2.Y - start2.Y) * (start1.X - start2.X)) / ((end2.Y - start2.Y) * (end1.X - start1.X) - (end2.X - start2.X) * (end1.Y - start1.Y));
            float uB = ((end1.X - start1.X) * (start1.Y - start2.Y) - (end1.Y - start1.Y) * (start1.X - start2.X)) / ((end2.Y - start2.Y) * (end1.X - start1.X) - (end2.X - start2.X) * (end1.Y - start1.Y));

            // if uA and uB are between 0-1, lines are colliding
            if (uA >= 0 && uA <= 1 && uB >= 0 && uB <= 1)
            {
                // point where the lines meet
                Vector2 intersectionPoint = new Vector2(
                    start1.X + (uA * (end1.X - start1.X)),
                    start1.Y + (uA * (end1.Y - start1.Y)));
                return true;
            }
            return false;
        }

        public static bool LineObj(Vector2 start, Vector2 end, GameObj obj)
        {
            // check if the line has hit any of the rectangle's sides
            // uses the Line/Line function below
            bool left = LineLine(start, end, obj.Rect.TopLeft, obj.Rect.BottomLeft);
            bool right = LineLine(start, end, obj.Rect.TopRight, obj.Rect.BottomRight);
            bool top = LineLine(start, end, obj.Rect.TopLeft, obj.Rect.TopRight);
            bool bottom = LineLine(start, end, obj.Rect.BottomLeft, obj.Rect.BottomRight);

            // if ANY of the above are true, the line
            // has hit the rectangle
            if (left || right || top || bottom)
            {
                return true;
            }
            return false;
        }

        #endregion

        public static bool ObjObj(GameObj obj1, GameObj obj2)
        {
            return obj1.Rect.Right >= obj2.X &&
                    obj1.X <= obj2.Rect.Right &&
                    obj1.Rect.Bottom >= obj2.Y &&
                    obj1.Y <= obj2.Rect.Bottom;
        }

        public static bool CircleObj(Vector2 center, float radius, GameObj obj)
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
