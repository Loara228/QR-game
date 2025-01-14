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

            Graphics.Initialize();

            Graphics.deviceManager.PreferredBackBufferWidth = 1280;
            Graphics.deviceManager.PreferredBackBufferHeight = 720;
            Graphics.deviceManager.ApplyChanges();
        }

        protected override void LoadContent()
        {
            Graphics.spriteBatch = new SpriteBatch(this.GraphicsDevice);

            Textures.Load(this.Content);
            Graphics.Load(this.Content);

            Game1._level = new TestLevel();
        }

        protected override void Update(GameTime gameTime)
        {
            Keyboard.Update();
            if (!Paused)
            {
                _level.Update();
            }
            Dev.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.AntiqueWhite);
            _level.Draw();
            //Graphics.spriteBatch.Begin();
            // UI
            //Graphics.spriteBatch.End();
            base.Draw(gameTime);
        }

        public static Level CurrentLevel
        {
            get => _level;
            set
            {
                _level = value;
                LevelChanged();
            }
        }

        private static void LevelChanged()
        {

        }

        public static bool Paused
        {
            get; set;
        }

        private static Level _level;
    }
}
