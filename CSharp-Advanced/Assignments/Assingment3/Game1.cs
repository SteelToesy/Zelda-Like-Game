using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Assignments.Assignment3
{
    public class Game1 : Game
    {
        public SceneManager sceneManager;
        private GraphicsDeviceManager _graphics;
        protected SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            //_graphics.PreferredBackBufferWidth = 1920;
            //_graphics.PreferredBackBufferHeight = 1000;

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new(GraphicsDevice);
            sceneManager = new(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            sceneManager.UpdateScene(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            sceneManager.DrawScene(_spriteBatch);
            _spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}