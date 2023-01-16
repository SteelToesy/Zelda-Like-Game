using Assignments.Assignment1;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Assignments.Assignment2
{
    internal class Weapon : GameObject
    {
        Player _player;
        
        private Texture2D _texture;
        
        public Weapon(Texture2D pTexture, Player pPlayer) : base("weapon", new Vector2(100, 200), pTexture)
        {
            _player = pPlayer;
            _texture = pTexture;
        }

        public override void Update(GameTime pGameTime, List<GameObject> pGameObjects)
        {
            base.Update(pGameTime, pGameObjects);
        }

        public override void OnCollision(List<GameObject> pGameObjects)
        {
            // If the player collides with the weapon, the player gets the weapon   
            if (collisionBox.Intersects(_player.collisionBox))
            {
                if (_player.textureIndexer == (int)PlayerTexture.PlayerWithShield)
                    _player.textureIndexer = (int)PlayerTexture.PlayerWithWeaponAndShield;
                else
                    _player.textureIndexer = (int)PlayerTexture.PlayerWithWeapon;
                enabled = false;
            }   
        }
        public override void Draw(SpriteBatch pSpritebatch)
        {
            pSpritebatch.Draw(_texture, _position, Color.White);
        }
    }
}
