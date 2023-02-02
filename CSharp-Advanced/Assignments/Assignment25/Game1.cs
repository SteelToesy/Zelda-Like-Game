using Assignments.Assignment3;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Assignments.Assignment25
{
    public enum Scenes
    {
        Menu,
        Level1,
        Level2,
        Level3,
        GameOver,
        Victory
    }
    public class Game1 : Game
    {
        public static Scenes currentScene = Scenes.Menu;
        public List<Scene> scenes = new List<Scene>();
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
            Level2 level2 = new(level1.gameObjects[0], Content);
            Level3 level3 = new(Content, level1.gameObjects[0]);
            GameOver gameOver = new(Content);
            GameVictory gameVictory = new(Content);

            scenes.Add(menu);
            scenes.Add(level1);
            scenes.Add(level2);
            scenes.Add(level3);
            scenes.Add(gameOver);
            scenes.Add(gameVictory);
        }

        protected override void Update(GameTime gameTime)
        {
            sceneManager.UpdateScene(scenes[(int)currentScene], gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            sceneManager.DrawScene(scenes[(int)currentScene], _spriteBatch);

            _spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}