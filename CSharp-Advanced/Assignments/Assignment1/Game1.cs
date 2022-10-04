using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Assignments.Assignment1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Texture2D player, 
                         gate,
                         shield,
                         sword, 
                         playerAndShield, 
                         playerAndSword, 
                         playerAndShieldAndSword;

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

            player = Content.Load<Texture2D>("Knight");
            gate = Content.Load<Texture2D>("Gate");
            shield = Content.Load<Texture2D>("Shield");
            sword = Content.Load<Texture2D>("Weapon");
            playerAndShield = Content.Load<Texture2D>("KnightShield");
            playerAndSword = Content.Load<Texture2D>("KnightWeapon");
            playerAndShieldAndSword = Content.Load<Texture2D>("KnightWeaponShield");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(player, new Vector2(100, 100), Color.White);
            _spriteBatch.Draw(gate, new Vector2(100, 100), Color.White);
            _spriteBatch.Draw(shield, new Vector2(100, 100), Color.White);
            _spriteBatch.Draw(sword, new Vector2(100, 100), Color.White);
            _spriteBatch.Draw(playerAndShield, new Vector2(100, 100), Color.White);
            _spriteBatch.Draw(playerAndSword, new Vector2(100, 100), Color.White);
            _spriteBatch.Draw(playerAndShieldAndSword, new Vector2(100, 100), Color.White);
            _spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}