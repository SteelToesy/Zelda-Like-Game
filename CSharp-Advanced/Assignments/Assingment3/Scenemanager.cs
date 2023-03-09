using Assignments.Assignment2;
using Assignments.Assingment3;
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
        private Scene _currentScene;

        public ContentManager content;
        public List<Scene> sceneList;

        public int enemiesKilled;

        public SceneManager(ContentManager pContent)
        {
            content = pContent;
            NewGame(content);
        }

        public void LoadScene(SceneTypes pScene)
        {
            foreach (Scene scene in sceneList)
                if (scene.type == pScene)
                    _currentScene = scene;
        }

        public void UpdateScene(GameTime gametime)
        {
            _currentScene.gameObjects.ForEach(obj => { if (obj.active) { obj.Update(gametime); } });
        }

        public void DrawScene(SpriteBatch pSpriteBatch)
        {
            _currentScene.gameObjects.ForEach(obj => { if (obj.active) { obj.Draw(pSpriteBatch); } });
        }

        public void NewGame(ContentManager pContent)
        {
            enemiesKilled = 0;

            Menu menu = new(pContent, this);
            Level1 level1 = new(pContent, this);
            Level2 level2 = new(pContent, this, level1.player, level1.healthBar);
            Level3 level3 = new(pContent, this, level1.player, level1.healthBar);
            GameOver gameOver = new(pContent, this);
            GameVictory victory = new(pContent, this);

            sceneList = new List<Scene>
            {
                menu,
                level1,
                level2,
                level3,
                gameOver,
                victory
            };

            _currentScene = menu;
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
        public HealthBar healthBar;
        public Level1(ContentManager pContent, SceneManager pSceneManager)
        {
            type = SceneTypes.Level1;

            Texture2D oneHP = pContent.Load<Texture2D>("Assets/Health-1HP");
            Texture2D twoHP = pContent.Load<Texture2D>("Assets/Health-2HP");
            Texture2D threeHP = pContent.Load<Texture2D>("Assets/Health-3HP");

            Texture2D knightTexture = pContent.Load<Texture2D>("Assets/Knight");
            Texture2D knightShieldTexture = pContent.Load<Texture2D>("Assets/KnightShield");
            Texture2D knightWeaponTexture = pContent.Load<Texture2D>("Assets/KnightWeapon");
            Texture2D knightWeaponShieldTexture = pContent.Load<Texture2D>("Assets/KnightWeaponShield");

            Texture2D gateTexture = pContent.Load<Texture2D>("Assets/Gate");
            Texture2D shieldTexture = pContent.Load<Texture2D>("Assets/Shield");
            Texture2D menuButtonTexture = pContent.Load<Texture2D>("Assets/UI_Tile_128x64_Menu");

            healthBar = new(new Vector2(375, 450), oneHP, twoHP, threeHP);
            player = new(new Vector2(400, 400), healthBar, pSceneManager, knightTexture, knightShieldTexture, knightWeaponTexture, knightWeaponShieldTexture);
            Shield shield = new(new Vector2(600, 200), shieldTexture, player, pSceneManager);
            Gate gate = new(new Vector2(400, 150), gateTexture, player, SceneTypes.Level2, pSceneManager);
            Gate gate2 = new(new Vector2(400, 0), gateTexture, player, SceneTypes.Level3, pSceneManager);
            MenuButton menuButton = new(new Vector2(0, 0), menuButtonTexture, pSceneManager);

            gameObjects.Add(player);
            gameObjects.Add(healthBar);
            gameObjects.Add(gate);
            gameObjects.Add(gate2);
            gameObjects.Add(menuButton);
            gameObjects.Add(shield);
        }
    }

    public class Level2 : Scene
    {
        public Level2(ContentManager pContent, SceneManager pSceneManager, Player pPlayer, HealthBar pHealthBar)
        {
            type = SceneTypes.Level2;

            Texture2D healthPickupTexture = pContent.Load<Texture2D>("Assets/HealthPickup");
            Texture2D weaponTexture = pContent.Load<Texture2D>("Assets/Weapon");
            Texture2D gateTexture = pContent.Load<Texture2D>("Assets/Gate");
            Texture2D menuButtonTexture = pContent.Load<Texture2D>("Assets/UI_Tile_128x64_Menu");

            HealthPickup healthPickup = new(new Vector2(100, 200), healthPickupTexture, pPlayer);
            Weapon weapon = new(new Vector2(200, 200), weaponTexture, pPlayer, pSceneManager);
            Gate gate = new(new(750, 0), gateTexture, pPlayer, SceneTypes.Level1, pSceneManager);
            MenuButton menuButton = new(new Vector2(0, 0), menuButtonTexture, pSceneManager);

            gameObjects.Add(pPlayer);
            gameObjects.Add(healthPickup);
            gameObjects.Add(pHealthBar);
            gameObjects.Add(gate);
            gameObjects.Add(menuButton);
            gameObjects.Add(weapon);
        }
    }
    
    public class Level3 : Scene
    {
        public Level3(ContentManager pContent, SceneManager pSceneManager, Player pPlayer, HealthBar pHealthBar)
        {
            type = SceneTypes.Level3;

            Texture2D knightTexture = pContent.Load<Texture2D>("Assets/Knight");
            Texture2D knightShieldTexture = pContent.Load<Texture2D>("Assets/KnightShield");
            Texture2D knightWeaponTexture = pContent.Load<Texture2D>("Assets/KnightWeapon");
            Texture2D knightWeaponShieldTexture = pContent.Load<Texture2D>("Assets/KnightWeaponShield");

            Texture2D enemyTexture = pContent.Load<Texture2D>("Assets/Enemy");
            Texture2D enemyTexture2 = pContent.Load<Texture2D>("Assets/Enemy2");

            Texture2D flagTexture = pContent.Load<Texture2D>("Assets/Flag");
            Texture2D gateTexture = pContent.Load<Texture2D>("Assets/Gate");
            Texture2D menuButtonTexture = pContent.Load<Texture2D>("Assets/UI_Tile_128x64_Menu");

            Gate gate = new(new(750, 0), gateTexture, pPlayer, SceneTypes.Level1, pSceneManager);
            Flag flag1 = new(new(200, 200), flagTexture);
            Flag flag2 = new(new(600, 200), flagTexture);
            Flag flag3 = new(new(400, 350), flagTexture);
            Enemy enemy = new(new(200, 200), enemyTexture, 50, pSceneManager, pPlayer, flag1, flag2, flag3);
            Flag flag4 = new(new(100, 400), flagTexture);
            Flag flag5 = new(new(400, 100), flagTexture);
            Flag flag6 = new(new(200, 350), flagTexture);
            Enemy enemy2 = new(new(600, 100), enemyTexture2, 150 ,pSceneManager, pPlayer, flag4, flag5, flag6);
            MenuButton menuButton = new(new Vector2(0, 0), menuButtonTexture, pSceneManager);

            gameObjects.Add(pHealthBar);
            gameObjects.Add(pPlayer);
            gameObjects.Add(gate);
            gameObjects.Add(flag1);
            gameObjects.Add(flag2);
            gameObjects.Add(flag3);
            gameObjects.Add(enemy);
            gameObjects.Add(flag4);
            gameObjects.Add(flag5);
            gameObjects.Add(flag6);
            gameObjects.Add(enemy2);
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

