using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;

namespace Assignments.Assignment2
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

            Texture2D knight = Content.Load<Texture2D>("Assets/Knight");

            
            //textures.Add(Content.Load<Texture2D>("Assets/Knight"));
            Texture2D tex1 = Content.Load<Texture2D>("Assets/KnightShield");
            Texture2D tex2 = Content.Load<Texture2D>("Assets/KnightWeapon");
            Texture2D tex3 = Content.Load<Texture2D>("Assets/KnightWeaponShield");
            Texture2D tex4 = Content.Load<Texture2D>("Assets/Gate");
            Texture2D tex5 = Content.Load<Texture2D>("Assets/Shield");
            Texture2D tex6 = Content.Load<Texture2D>("Assets/Weapon");

            Player player = new Player(knight, tex1, tex2, tex3);
            gameObjects.Add(player);
            gameObjects.Add(new Weapon(tex6, player));
            gameObjects.Add(new Shield(tex5));
            gameObjects.Add(new Gate(tex4));
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach (var gameObject in gameObjects.Where((GameObject x) => x.enabled)) 
                gameObject.Update(gameTime, gameObjects);

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();
            foreach (var gameObject in gameObjects.Where((GameObject x) => x.enabled))
                gameObject.Draw(_spriteBatch);
            _spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}