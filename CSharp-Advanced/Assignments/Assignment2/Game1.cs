using Assignments.Assignment3;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Assignments.Assignment2
{
    public enum Scenes
    {
        Menu,
        Level1,
        Level2
    }
    public class Game1 : Game
    {
        public SceneManager sceneManager;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

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