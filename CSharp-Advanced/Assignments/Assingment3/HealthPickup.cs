using Assignments.Assignment3;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Assignments.Assingment3
{
    public class HealthPickup : GameObject
    {
        private Player _player;
        public HealthPickup(Vector2 pPosition, Texture2D pTexture, Player pPlayer) : base(pPosition, pTexture)
        {
            position = pPosition;
            _texture = pTexture;
            _player = pPlayer;
        }

        public override void Update(GameTime pGameTime)
        {
            OnCollision();
            base.Update(pGameTime);
        }

        public override void Draw(SpriteBatch pSpritebatch)
        {
            pSpritebatch.Draw(_texture, position, Color.White);
        }

        public override void OnCollision()
        {
            if (collisionBox.Intersects(_player.collisionBox))
            {
                _player.Heal();
                active = false;
            }
        }
    }
}
