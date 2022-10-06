using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Assignments.Assignment1
{
    public class Game1 : Game
    {
        public List<GameObject> gameObjects = new List<GameObject>();
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
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            Texture2D playerTexture = Content.Load<Texture2D>("Assets/Knight");
            Texture2D gate = Content.Load<Texture2D>("Assets/Gate");
            Texture2D shield = Content.Load<Texture2D>("Assets/Shield");
            Texture2D weapon = Content.Load<Texture2D>("Assets/Weapon");

            gameObjects.Add(new Player(playerTexture));
            gameObjects.Add(new Weapon(weapon));
            gameObjects.Add(new Shield(shield));
            gameObjects.Add(new Gate(gate));
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach (var gameObject in gameObjects)
                gameObject.Update(gameTime, gameObjects);

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();
            foreach (var gameObject in gameObjects)
                gameObject.Draw(_spriteBatch);
            _spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}