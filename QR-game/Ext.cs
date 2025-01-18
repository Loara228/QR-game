namespace QR_game
{
    public static class Ext
    {
        public static Microsoft.Xna.Framework.Rectangle ToXna(this SharpDX.RectangleF rect)
        {
            return new Microsoft.Xna.Framework.Rectangle((int)rect.X, (int)rect.Y, (int)rect.Width, (int)rect.Height);
        }
    }
}
