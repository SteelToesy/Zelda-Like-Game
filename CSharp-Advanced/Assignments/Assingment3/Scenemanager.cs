using Assignments.Assignment2;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Assignments.Assignment3
{
    public enum SceneTypes
    {
        Menu,
        Level1,
        Level2,
        Level3,
        GameOver,
        Victory
    }

    public class SceneManager
    {
        private ContentManager content;
        public List<Scene> sceneList;

        private Scene currentScene;

        public SceneManager(ContentManager pContent)
        {
            content = pContent;

            Menu menu = new(pContent, this);
            Level1 level1 = new(pContent, this);
            Level2 level2 = new(pContent, this, level1.player);
            Level3 level3 = new(pContent, this, level1.player);

            sceneList = new List<Scene>
            {
                menu,
                level1,
                level2,
                level3
            };

            currentScene = menu;
        }

        public void LoadScene(SceneTypes pScene)
        {
            foreach (Scene scene in sceneList)
                if (scene.type == pScene)
                    currentScene = scene;
        }

        //I want to be able to Update different scenes here
        public void UpdateScene(GameTime gametime)
        {
            currentScene.gameObjects.ForEach(obj => { if (obj.active) { obj.Update(gametime); } });
        }

        //I want to be able to Draw scenes here
        public void DrawScene(SpriteBatch pSpriteBatch)
        {
            currentScene.gameObjects.ForEach(obj => { if (obj.active) { obj.Draw(pSpriteBatch); } });
        }
    }

    public class Scene
    {
        public SceneTypes type;
        public List<GameObject> gameObjects = new();
    }

    public class Menu : Scene
    {
        public Menu(ContentManager pContent, SceneManager pSceneManager)
        {
            type = SceneTypes.Menu;

            Texture2D playButtonTexture = pContent.Load<Texture2D>("Assets/UI_Tile_128x64_Play");
            Texture2D quitButtonTexture = pContent.Load<Texture2D>("Assets/UI_Tile_128x64_Quit");

            PlayButton playButton = new(new(350, 200), playButtonTexture, pSceneManager);
            QuitButton quitButton = new(new(350, 275), quitButtonTexture);

            gameObjects.Add(playButton);
            gameObjects.Add(quitButton);
        }
    }

    public class Level1 : Scene
    {
        public Player player;
        public Level1(ContentManager pContent, SceneManager pSceneManager)
        {
            type = SceneTypes.Level1;

            Texture2D knightTexture = pContent.Load<Texture2D>("Assets/Knight");
            Texture2D knightShieldTexture = pContent.Load<Texture2D>("Assets/KnightShield");
            Texture2D knightWeaponTexture = pContent.Load<Texture2D>("Assets/KnightWeapon");
            Texture2D knightWeaponShieldTexture = pContent.Load<Texture2D>("Assets/KnightWeaponShield");

            Texture2D gateTexture = pContent.Load<Texture2D>("Assets/Gate");
            Texture2D shieldTexture = pContent.Load<Texture2D>("Assets/Shield");
            Texture2D menuButtonTexture = pContent.Load<Texture2D>("Assets/UI_Tile_128x64_Menu");

            player = new(new Vector2(400, 400), knightTexture, knightShieldTexture, knightWeaponTexture, knightWeaponShieldTexture);
            Shield shield = new(new Vector2(600, 200), shieldTexture, player, pSceneManager);
            Gate gate = new(new Vector2(400, 150), gateTexture, player, SceneTypes.Level2, pSceneManager);
            Gate gate2 = new(new Vector2(200, 200), gateTexture, player, SceneTypes.Level3, pSceneManager);
            MenuButton menuButton = new(new Vector2(0, 0), menuButtonTexture, pSceneManager);

            gameObjects.Add(player);
            gameObjects.Add(gate);
            gameObjects.Add(gate2);
            gameObjects.Add(menuButton);
            gameObjects.Add(shield);
        }
    }

    public class Level2 : Scene
    {
        public Level2(ContentManager pContent, SceneManager pSceneManager, Player pPlayer)
        {
            type = SceneTypes.Level2;

            Texture2D knightTexture = pContent.Load<Texture2D>("Assets/Knight");
            Texture2D knightShieldTexture = pContent.Load<Texture2D>("Assets/KnightShield");
            Texture2D knightWeaponTexture = pContent.Load<Texture2D>("Assets/KnightWeapon");
            Texture2D knightWeaponShieldTexture = pContent.Load<Texture2D>("Assets/KnightWeaponShield");

            Texture2D weaponTexture = pContent.Load<Texture2D>("Assets/Weapon");
            Texture2D gateTexture = pContent.Load<Texture2D>("Assets/Gate");
            Texture2D menuButtonTexture = pContent.Load<Texture2D>("Assets/UI_Tile_128x64_Menu");

            Player player = pPlayer;
            Weapon weapon = new(new Vector2(200, 200), weaponTexture, player, pSceneManager);
            Gate gate = new(new(750, 0), gateTexture, player, SceneTypes.Level1, pSceneManager);
            MenuButton menuButton = new(new Vector2(0, 0), menuButtonTexture, pSceneManager);

            gameObjects.Add(player);
            gameObjects.Add(gate);
            gameObjects.Add(menuButton);
            gameObjects.Add(weapon);
        }
    }
    
    public class Level3 : Scene
    {
        public Level3(ContentManager pContent, SceneManager pSceneManager, Player pPlayer)
        {
            type = SceneTypes.Level3;

            Texture2D knightTexture = pContent.Load<Texture2D>("Assets/Knight");
            Texture2D knightShieldTexture = pContent.Load<Texture2D>("Assets/KnightShield");
            Texture2D knightWeaponTexture = pContent.Load<Texture2D>("Assets/KnightWeapon");
            Texture2D knightWeaponShieldTexture = pContent.Load<Texture2D>("Assets/KnightWeaponShield");

            Texture2D enemyTexture = pContent.Load<Texture2D>("Assets/Enemy");
            Texture2D flagTexture = pContent.Load<Texture2D>("Assets/Flag");
            Texture2D gateTexture = pContent.Load<Texture2D>("Assets/Gate");
            Texture2D menuButtonTexture = pContent.Load<Texture2D>("Assets/UI_Tile_128x64_Menu");

            Gate gate = new(new(750, 0), gateTexture, pPlayer, SceneTypes.Level1, pSceneManager);
            Flag flag1 = new(new(200, 200), flagTexture);
            Flag flag2 = new(new(600, 200), flagTexture);
            Flag flag3 = new(new(400, 350), flagTexture);
            Enemy enemy = new(new(200, 200), enemyTexture, pPlayer, flag1, flag2, flag3);
            MenuButton menuButton = new(new Vector2(0, 0), menuButtonTexture, pSceneManager);

            gameObjects.Add(pPlayer);
            gameObjects.Add(gate);
            gameObjects.Add(flag1);
            gameObjects.Add(flag2);
            gameObjects.Add(flag3);
            gameObjects.Add(enemy);
            gameObjects.Add(menuButton);
        }
    }

    public class GameOver : Scene
    {
        public GameOver(ContentManager Content, SceneManager pSceneManager)
        {
            type = SceneTypes.GameOver;

            Texture2D defeatTexture = Content.Load<Texture2D>("Assets/Defeat");
            Texture2D playButtonTexture = Content.Load<Texture2D>("Assets/UI_Tile_128x64_Play");
            Texture2D quitButtonTexture = Content.Load<Texture2D>("Assets/UI_Tile_128x64_Quit");

            Image defeatImage = new(new(275, 50), defeatTexture);
            PlayButton playButton = new(new(350, 275), playButtonTexture, pSceneManager);
            QuitButton quitButton = new(new(350, 350), quitButtonTexture);
            
            gameObjects.Add(defeatImage);
            gameObjects.Add(playButton);
            gameObjects.Add(quitButton);
        }
    }

    public class GameVictory : Scene
    {
        public GameVictory(ContentManager Content, SceneManager pSceneManager)
        {
            type = SceneTypes.Victory;

            Texture2D victoryTexture = Content.Load<Texture2D>("Assets/Victory");
            Texture2D playButtonTexture = Content.Load<Texture2D>("Assets/UI_Tile_128x64_Play");
            Texture2D quitButtonTexture = Content.Load<Texture2D>("Assets/UI_Tile_128x64_Quit");

            Image victoryImage = new(new(275, 50), victoryTexture);
            PlayButton playButton = new(new(350, 275), playButtonTexture, pSceneManager);
            QuitButton quitButton = new(new(350, 350), quitButtonTexture);
            
            gameObjects.Add(victoryImage);
            gameObjects.Add(playButton);
            gameObjects.Add(quitButton);
        }
    }
    
}

