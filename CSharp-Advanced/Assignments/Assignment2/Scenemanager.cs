using Microsoft.Xna.Framework;
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

        public SceneManager()
        {

        }

        //I want to be able to load different scenes here
        public void LoadScene(Scenes pScnene)
        {
            //foreach gameobject in pScene load their content
        }

        //I want to be able to unload scenes here
        public void UnloadScene(Scenes pScnene)
        {

        }
    }

    public class Scenes
    {
        public Scenes()
        {

        }
    }

    public class Menu : Scenes
    {
        
        List<GameObject> gameObjects = new List<GameObject>();
        public Menu()
        {
            //add all gameobjects that are supposed to be in the menu
        }
    }

    public class Level1 : Scenes
    {

        List<GameObject> gameObjects = new List<GameObject>();

        Player player = new Player();
        Weapon weapon = new Weapon();
        Shield shield = new Shield();
        public Level1(SpriteBatch spriteBatch)
        {

            //Textures for the player
            Texture2D knight = Content.Load<Texture2D>("Assets/Knight");
            Texture2D knightShield = Content.Load<Texture2D>("Assets/KnightShield");
            Texture2D knightWeapon = Content.Load<Texture2D>("Assets/KnightWeapon");
            Texture2D knightWeaponShield = Content.Load<Texture2D>("Assets/KnightWeaponShield");
        }
    }
}
