using Assignments.Assignment1;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Assignments.Assignment2
{
    internal class Shield : GameObject
    {
        Player _player;
        private Texture2D _texture;
        public Shield(Texture2D pTexture, Player pPlayer) : base("shield", new Vector2(600, 200), pTexture)
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
            if (this.collisionBox.Intersects(pGameObjects[0].collisionBox))
            {
                if (_player.textureIndexer == (int)PlayerTexture.PlayerWithWeapon)
                    _player.textureIndexer = (int)PlayerTexture.PlayerWithWeaponAndShield;
                else
                    _player.textureIndexer = (int)PlayerTexture.PlayerWithShield;
                enabled = false;
            }
        }
        public override void Draw(SpriteBatch pSpritebatch)
        {
            pSpritebatch.Draw(_texture, _position, Color.White);
        }
    }
}
