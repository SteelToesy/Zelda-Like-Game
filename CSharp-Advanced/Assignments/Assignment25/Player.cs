using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Linq;

namespace Assignments.Assignment25
{
    public enum PlayerTexture
    {
        Player,
        PlayerWithShield,
        PlayerWithWeapon,
        PlayerWithWeaponAndShield,
    }
    internal class Player : GameObject 
    {
        private float _speed = 5f;
        
        public Texture2D texture
        {
            get => _textures[textureIndexer];
        }

        public Player(params Texture2D[] pTextures) : base ("Player")
        {
            _textures = pTextures.ToList();
            _texture = pTextures[0];
        }

        public override void Update(GameTime pGameTime)
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


            base.Update(pGameTime);  
        }
        public override void Draw(SpriteBatch pSpritebatch)
        {
            pSpritebatch.Draw(texture, position, Color.White);
        }
    }
}
