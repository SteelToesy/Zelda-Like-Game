using Microsoft.Xna.Framework;
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
            pScnene.gameObjects.ForEach(obj => { if (obj.active) { obj.Update(gametime); } });
        }

        //I want to be able to Draw scenes here
        public void DrawScene(Scene pScnene, SpriteBatch pSpriteBatch)
        {
            pScnene.gameObjects.ForEach(obj => { if (obj.active) { obj.Draw(pSpriteBatch); } });
        }
    }

    public class Scene
    {
        public List<GameObject> gameObjects = new List<GameObject>();
        public List<Texture2D> textures = new List<Texture2D>();
    }

    public class Menu : Scene
    {
        public Menu(ContentManager Content)
        {
            #region Textures for the playButton and quitButton
            Texture2D playButtonTexture = Content.Load<Texture2D>("Assets/UI_Tile_128x64_Play");
            textures.Add(playButtonTexture);

            Texture2D quitButtonTexture = Content.Load<Texture2D>("Assets/UI_Tile_128x64_Quit");
            textures.Add(quitButtonTexture);
            #endregion

            PlayButton playButton = new(playButtonTexture);
            QuitButton quitButton = new(quitButtonTexture);
            gameObjects.Add(playButton);
            gameObjects.Add(quitButton);

            playButton.position = new(350, 200);
            quitButton.position = new(350, 275);
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

            #region Textures for the menuButton
            Texture2D menuButtonTexture = Content.Load<Texture2D>("Assets/UI_Tile_128x64_Menu");
            textures.Add(menuButtonTexture);
            #endregion

            Player player = new(knightTexture, knightShieldTexture, knightWeaponTexture, knightWeaponShieldTexture);
            Weapon weapon = new(weaponTexture, player);
            Shield shield = new(shieldTexture, player);
            Gate gate = new(gateTexture, player, Scenes.Level2);
            MenuButton menuButton = new(menuButtonTexture);

            gameObjects.Add(player);
            gameObjects.Add(weapon);
            gameObjects.Add(shield);
            gameObjects.Add(gate);
            gameObjects.Add(menuButton);

            player.position = new Vector2(400, 400);
            weapon.position = new Vector2(200, 200);
            shield.position = new Vector2(600, 200);
            gate.position = new Vector2(400, 150);
            menuButton.position = new Vector2(0, 0);
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

            #region Textures for the menuButton
            Texture2D menuButtonTexture = Content.Load<Texture2D>("Assets/UI_Tile_128x64_Menu");
            textures.Add(menuButtonTexture);
            #endregion

            GameObject player = pPlayer;
            Gate gate = new(gateTexture, player, Scenes.Level1);
            Flag flag1 = new(flagTexture);
            Flag flag2 = new(flagTexture);
            Flag flag3 = new(flagTexture);
            Enemy enemy = new(enemyTexture, player, flag1, flag2, flag3);
            MenuButton menuButton = new(menuButtonTexture);

            gameObjects.Add(enemy);
            gameObjects.Add(player);
            gameObjects.Add(gate);
            gameObjects.Add(flag1);
            gameObjects.Add(flag2);
            gameObjects.Add(flag3);
            gameObjects.Add(menuButton);

            gate.position = new(720, 0);
            enemy.position = new(200, 200);
            flag1.position = new(200, 200);
            flag2.position = new(600, 200);
            flag3.position = new(400, 400);
            menuButton.position = new Vector2(0, 0);
        }
    }
}
