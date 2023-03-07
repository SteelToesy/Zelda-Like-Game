using Assignments.Assignment1;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Assignments.Assignment3
{
    class Weapon : GameObject
    {
        SceneManager sceneManager;
        GameObject _player;
                
        public Weapon(Vector2 pPosition, Texture2D pTexture, GameObject pPlayer, SceneManager pSceneManager) : base(pPosition)
        {
            sceneManager = pSceneManager;
            _player = pPlayer;
            _texture = pTexture;
        }

        public override void Update(GameTime pGameTime)
        {
            base.Update(pGameTime);
        }

        public override void OnCollision()
        {
            // If the player collides with the weapon, the player gets the weapon   
            if (collisionBox.Intersects(_player.collisionBox))
            {
                if (_player.textureIndexer == (int)PlayerTexture.PlayerWithShield)
                    _player.textureIndexer = (int)PlayerTexture.PlayerWithWeaponAndShield;
                else
                    _player.textureIndexer = (int)PlayerTexture.PlayerWithWeapon;
                active = false;
            }   
        }
        public override void Draw(SpriteBatch pSpritebatch)
        {
            pSpritebatch.Draw(_texture, position, Color.White);
        }
    }
}
