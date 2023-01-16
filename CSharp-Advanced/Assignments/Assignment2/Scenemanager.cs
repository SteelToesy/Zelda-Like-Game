using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Assignments.Assignment2
{
    public class SceneManager
    {

        //I want to be able to Update different scenes here
        public void UpdateScene(Scenes pScnene, GameTime gametime)
        {
            pScnene.gameObjects.ForEach(obj => { obj.Update(gametime); });
        }

        //I want to be able to Draw scenes here
        public void DrawScene(Scenes pScnene, SpriteBatch pSpriteBatch)
        {
            pScnene.gameObjects.ForEach(obj => { obj.Draw(pSpriteBatch); });
        }
    }

    public class Scenes
    {
        //protected ContentManager Content;
        public List<GameObject> gameObjects = new List<GameObject>();
        public List<Texture2D> textures = new List<Texture2D>();
    }

    public class Menu : Scenes
    {
        public Menu(ContentManager Content)
        {
            //add all gameobjects that are supposed to be in the menu
        }
    }

    public class Level1 : Scenes
    {
        public Level1(ContentManager Content)
        {
            //Textures for the player
            Texture2D knightTexture = Content.Load<Texture2D>("Assets/Knight");
            Texture2D knightShieldTexture = Content.Load<Texture2D>("Assets/KnightShield");
            Texture2D knightWeaponTexture = Content.Load<Texture2D>("Assets/KnightWeapon");
            Texture2D knightWeaponShieldTexture = Content.Load<Texture2D>("Assets/KnightWeaponShield");

            textures.Add(knightTexture);
            textures.Add(knightShieldTexture);
            textures.Add(knightWeaponTexture);
            textures.Add(knightWeaponShieldTexture);

            Texture2D gateTexture = Content.Load<Texture2D>("Assets/Gate");
            Texture2D shieldTexture = Content.Load<Texture2D>("Assets/Shield");
            Texture2D weaponTexture = Content.Load<Texture2D>("Assets/Weapon");

            textures.Add(gateTexture);
            textures.Add(shieldTexture);
            textures.Add(weaponTexture);

            Player player = new Player(knightTexture, knightShieldTexture, knightWeaponTexture, knightWeaponShieldTexture);
            Weapon weapon = new Weapon(weaponTexture, player);
            Shield shield = new Shield(shieldTexture, player);
            Gate gate = new Gate(gateTexture);

            gameObjects.Add(weapon);
            gameObjects.Add(shield);
            gameObjects.Add(player);
            gameObjects.Add(gate);
        }
    }
}
