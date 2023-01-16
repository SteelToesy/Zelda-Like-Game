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
            pScnene.gameObjects.ForEach(obj => { if (obj.active) { obj.Update(gametime); }});
        }

        //I want to be able to Draw scenes here
        public void DrawScene(Scenes pScnene, SpriteBatch pSpriteBatch)
        {
            pScnene.gameObjects.ForEach(obj => { if (obj.active) { obj.Draw(pSpriteBatch); } });
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
            Gate gate = new Gate(gateTexture, player);

            gameObjects.Add(weapon);
            gameObjects.Add(shield);
            gameObjects.Add(player);
            gameObjects.Add(gate);

            player.position = new Vector2(400 , 400);
            weapon.position = new Vector2(200, 200);
            shield.position = new Vector2(600, 200);
            gate.position = new Vector2(400, 150);
        }
    }

    public class Level2 : Scenes
    {
        public Level2(ContentManager Content)
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
            textures.Add(gateTexture);

            Player player = new Player(knightTexture, knightShieldTexture, knightWeaponTexture, knightWeaponShieldTexture);
            Gate gate = new Gate(gateTexture, player);

            gameObjects.Add(player);
            gameObjects.Add(gate);

            player.position = new Vector2(400, 400);
            gate.position = new Vector2(400, 150);
        }
    }
}
