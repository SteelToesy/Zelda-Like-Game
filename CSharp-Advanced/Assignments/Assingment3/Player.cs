using Assignments.Assingment3;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignments.Assignment3
{
    public enum PlayerTexture
    {
        Player,
        PlayerWithShield,
        PlayerWithWeapon,
        PlayerWithWeaponAndShield,
    }
    public class Player : GameObject 
    {
        private float _speed = 5f;
        private HealthBar _healthbar;
        private SceneManager _sceneManager;

        public Texture2D texture
        {
            get => _textures[textureIndexer];
        }

        public Player(Vector2 pPosition, HealthBar pHealthBar, SceneManager pSceneManager, params Texture2D[] pTextures) : base(pPosition, pTextures)
        {
            position= pPosition;
            _textures = pTextures.ToList();
            _texture = pTextures[0];
            _healthbar = pHealthBar;
            _sceneManager = pSceneManager;
        }

        public override void Update(GameTime pGameTime)
        {
            Movement();

            base.Update(pGameTime);  
        }
        public override void Draw(SpriteBatch pSpritebatch)
        {
            pSpritebatch.Draw(texture, position, Color.White);
        }

        public void Movement()
        {
            // Normailized movement
            Vector2 movement = Vector2.Zero;
            if (Keyboard.GetState().IsKeyDown(Keys.W))
                movement.Y -= 1;
            if (Keyboard.GetState().IsKeyDown(Keys.S))
                movement.Y += 1;
            if (Keyboard.GetState().IsKeyDown(Keys.A))
                movement.X -= 1;
            if (Keyboard.GetState().IsKeyDown(Keys.D))
                movement.X += 1;
            if (movement != Vector2.Zero)
                movement.Normalize();
            position = new Vector2(position.X + movement.X * _speed, position.Y + movement.Y * _speed);
        }
        
        public void TakeDamage()
        {
            position = new Vector2(100, 0);
            _healthbar.health--;
            if (_healthbar.health <= 0)
                _sceneManager.LoadScene(SceneTypes.GameOver);
        }

        public void Heal()
        {
            if (_healthbar.health != 3)
                _healthbar.health++;
        }
    }
}
