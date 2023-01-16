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

        Menu menu = new Menu();
        Level1 level1 = new Level1();

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
            // TODO: Add your initialization logic here
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            //Textures for the player
            Texture2D knight = Content.Load<Texture2D>("Assets/Knight");
            Texture2D knightShield = Content.Load<Texture2D>("Assets/KnightShield");
            Texture2D knightWeapon = Content.Load<Texture2D>("Assets/KnightWeapon");
            Texture2D knightWeaponShield = Content.Load<Texture2D>("Assets/KnightWeaponShield");
            
            Texture2D gate = Content.Load<Texture2D>("Assets/Gate");
            Texture2D shield = Content.Load<Texture2D>("Assets/Shield");
            Texture2D weapon = Content.Load<Texture2D>("Assets/Weapon");

            //Create the objects
            Player player = new Player(knight, knightShield, knightWeapon, knightWeaponShield);
            Shield shieldObject = new Shield(shield, player);
            Weapon weaponObject = new Weapon(weapon, player);
            Gate gateObject = new Gate(gate);

            sceneManager.LoadScene(sceneManager.scenes[1]);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //Update each gameobject
            //foreach gameobject in "scene" => Update

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //Draw each gameobject
            _spriteBatch.Begin();
            //foreach gameobject in "scene" => Draw

            _spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}