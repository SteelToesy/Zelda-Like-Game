﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Assignments.Assignment2
{
    public class SceneManager
    {
        //I want to be able to Update different scenes here
        public void UpdateScene(Scene pScnene, GameTime gametime)
        {
            pScnene.gameObjects.ForEach(obj => { if (obj.active) { obj.Update(gametime); }});
        }

        //I want to be able to Draw scenes here
        public void DrawScene(Scene pScnene, SpriteBatch pSpriteBatch)
        {
            pScnene.gameObjects.ForEach(obj => { if (obj.active) { obj.Draw(pSpriteBatch); } });
        }
    }

    public class Scene
    {
        //protected ContentManager Content;
        public List<GameObject> gameObjects = new List<GameObject>();
        public List<Texture2D> textures = new List<Texture2D>();
    }

    public class Menu : Scene
    {
        public Menu(ContentManager Content)
        {
            #region Textures for the button
            Texture2D startButtonTexture = Content.Load<Texture2D>("Assets/UI_Tile_128x64");
            textures.Add(startButtonTexture);
            #endregion

            Button startButton = new(startButtonTexture, Scenes.Level1);
            gameObjects.Add(startButton);

            startButton.position = new Vector2(350, 225);
        }
    }

    public class Level1 : Scene
    {
        public Level1(ContentManager Content)
        {
            #region Textures for the player
            Texture2D knightTexture = Content.Load<Texture2D>("Assets/Knight");
            Texture2D knightShieldTexture = Content.Load<Texture2D>("Assets/KnightShield");
            Texture2D knightWeaponTexture = Content.Load<Texture2D>("Assets/KnightWeapon");
            Texture2D knightWeaponShieldTexture = Content.Load<Texture2D>("Assets/KnightWeaponShield");

            textures.Add(knightTexture);
            textures.Add(knightShieldTexture);
            textures.Add(knightWeaponTexture);
            textures.Add(knightWeaponShieldTexture);
            #endregion

            #region Textures for the Gate
            Texture2D gateTexture = Content.Load<Texture2D>("Assets/Gate");
            textures.Add(gateTexture);
            #endregion

            #region Textures for the shield
            Texture2D shieldTexture = Content.Load<Texture2D>("Assets/Shield");
            textures.Add(shieldTexture);
            #endregion

            #region Texture for the weapon
            Texture2D weaponTexture = Content.Load<Texture2D>("Assets/Weapon");
            textures.Add(weaponTexture);
            #endregion

            Player player = new(knightTexture, knightShieldTexture, knightWeaponTexture, knightWeaponShieldTexture);
            Weapon weapon = new(weaponTexture, player);
            Shield shield = new(shieldTexture, player);
            Gate gate = new(gateTexture, player, Scenes.Level2);

            gameObjects.Add(player);
            gameObjects.Add(weapon);
            gameObjects.Add(shield);
            gameObjects.Add(gate);

            player.position = new Vector2(400 , 400);
            weapon.position = new Vector2(200, 200);
            shield.position = new Vector2(600, 200);
            gate.position = new Vector2(400, 150);
        }
    }

    public class Level2 : Scene
    {
        public Level2(ContentManager Content, GameObject pPlayer)
        {
            #region Textures for the player
            Texture2D knightTexture = Content.Load<Texture2D>("Assets/Knight");
            Texture2D knightShieldTexture = Content.Load<Texture2D>("Assets/KnightShield");
            Texture2D knightWeaponTexture = Content.Load<Texture2D>("Assets/KnightWeapon");
            Texture2D knightWeaponShieldTexture = Content.Load<Texture2D>("Assets/KnightWeaponShield");

            textures.Add(knightTexture);
            textures.Add(knightShieldTexture);
            textures.Add(knightWeaponTexture);
            textures.Add(knightWeaponShieldTexture);
            #endregion

            #region Textures for the enemy
            Texture2D enemyTexture = Content.Load<Texture2D>("Assets/Enemy");
            textures.Add(enemyTexture);
            #endregion

            #region Textures for the flag
            Texture2D flagTexture = Content.Load<Texture2D>("Assets/Flag");
            textures.Add(flagTexture);
            #endregion

            #region Textures for the Gate
            Texture2D gateTexture = Content.Load<Texture2D>("Assets/Gate");
            textures.Add(gateTexture);
            #endregion

            //made player a gameobject so that it can be passed from level1 to level2, don't like the way i'm doing this
            GameObject player = pPlayer;
            Gate gate = new(gateTexture, player, Scenes.Level1);
            Flag flag1 = new(flagTexture);
            Flag flag2 = new(flagTexture);
            Flag flag3 = new(flagTexture);
            Enemy enemy = new(enemyTexture, flag1, flag2, flag3);

            gameObjects.Add(enemy);
            gameObjects.Add(player);
            gameObjects.Add(gate);
            gameObjects.Add(flag1);
            gameObjects.Add(flag2);
            gameObjects.Add(flag3);

            gate.position = new Vector2(0, 0);
            flag1.position = new Vector2(200, 200);
            flag2.position = new Vector2(200, 600);
            flag3.position = new Vector2(400, 400);
        }
    }
}
