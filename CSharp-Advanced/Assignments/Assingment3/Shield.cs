using Assignments.Assignment1;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Assignments.Assignment3
{
    internal class Shield : GameObject
    {
        private SceneManager _sceneManager;
        private Player _player;
        public Shield(Vector2 pPosition, Texture2D pTexture, Player pPlayer, SceneManager pSceneManager) : base(pPosition)
        {
            _sceneManager = pSceneManager;
            _player = pPlayer;
            _texture = pTexture;
        }
        public override void Update(GameTime pGameTime)
        {
            base.Update(pGameTime);
        }
        public override void OnCollision()
        {
            // If the player collides with the shield, the player gets the shield
            if (this.collisionBox.Intersects(_player.collisionBox))
            {
                if (_player.textureIndexer == (int)PlayerTexture.PlayerWithWeapon)
                    _player.textureIndexer = (int)PlayerTexture.PlayerWithWeaponAndShield;
                else
                    _player.textureIndexer = (int)PlayerTexture.PlayerWithShield;
                active = false;
            }
        }
        public override void Draw(SpriteBatch pSpritebatch)
        {
            pSpritebatch.Draw(_texture, position, Color.White);
        }
    }
}
