using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Assignments.Assignment25
{
    internal class Weapon : GameObject
    {
        GameObject _player;
                
        public Weapon(Texture2D pTexture, GameObject pPlayer) : base ("Weapon")
        {
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
