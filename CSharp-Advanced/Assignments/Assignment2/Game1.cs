using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;

namespace Assignments.Assignment2
{
    public class Game1 : Game
    {
        public List<Scenes> scenes = new List<Scenes>();
        public SceneManager sceneManager = new SceneManager();

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

            Menu menu = new(Content);
            Level1 level1 = new(Content);

            scenes.Add(menu);
            scenes.Add(level1);
        }

        protected override void Update(GameTime gameTime)
        {
            sceneManager.UpdateScene(scenes[1], gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            sceneManager.DrawScene(scenes[1], _spriteBatch);

            _spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}