using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;

namespace Assignments.Assignment1
{
    public class Game1 : Game
    {
        public List<GameObject> gameObjects = new List<GameObject>();
        public List<Texture2D> textures = new List<Texture2D>();
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
            Texture2D playerWeapon = Content.Load<Texture2D>("Assets/KnightWeapon");
            Texture2D playerShield = Content.Load<Texture2D>("Assets/KnightShield");
            Texture2D playerWeaponShield = Content.Load<Texture2D>("Assets/KnightWeaponShield");
            
            textures.Add(playerTexture);
            textures.Add(playerShield);
            textures.Add(playerWeapon);
            textures.Add(playerWeaponShield);
            textures.Add(gate);
            textures.Add(shield);
            textures.Add(weapon);

            gameObjects.Add(new Player(textures[0], textures[1], textures[2], textures[3]));
            gameObjects.Add(new Weapon(textures[6]));
            gameObjects.Add(new Shield(textures[5]));
            gameObjects.Add(new Gate(textures[4]));
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach (var gameObject in gameObjects.Where((GameObject x) => x.enabled)) 
                gameObject.Update(gameTime, gameObjects, textures);

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