using QR_game;

using var game = new Game1();
game.Window.TextInput += (s, e) =>
{
    if ((int)(e.Key) >= 48 && (int)(e.Key) <= 57)
        Keyboard.Input += e.Character;
};
game.Window.KeyDown += (s, e) =>
{
    if (e.Key == Microsoft.Xna.Framework.Input.Keys.Enter)
            Keyboard.EnterPressed();
};

game.Run();