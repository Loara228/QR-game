using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using QR_game.Levels;

namespace QR_game
{
    public class Game1 : Game
    {
        public Game1()
        {
            Graphics.deviceManager = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
            
        protected override void Initialize()
        {
            base.Initialize();

            Graphics.deviceManager.PreferredBackBufferWidth = 1280;
            Graphics.deviceManager.PreferredBackBufferHeight = 720;
            Graphics.deviceManager.ApplyChanges();
        }

        protected override void LoadContent()
        {
            Graphics.spriteBatch = new SpriteBatch(this.GraphicsDevice);

            Textures.Load(this.Content);

            this._level = new TestLevel();
        }

        protected override void Update(GameTime gameTime)
        {
            Keyboard.Update();

            _level.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            Graphics.spriteBatch.Begin();
            _level.Draw();
            Graphics.spriteBatch.End();

            base.Draw(gameTime);
        }

        public Level CurrentLevel
        {
            get => _level;
        }

        private Level _level;
    }
}
