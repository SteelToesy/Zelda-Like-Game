using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignments.Assignment2
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
        
        protected List<Texture2D> _textures = new List<Texture2D>();
        public Texture2D texture
        {
            get => _textures[textureIndexer];
        }

        public Player(params Texture2D[] textures) : base("player", new Vector2(400, 400), textures)
        {
            _textures = textures.ToList();
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
            _position = new Vector2(_position.X + movement.X * _speed, _position.Y + movement.Y * _speed);


            base.Update(pGameTime);  
        }
        public override void Draw(SpriteBatch pSpritebatch)
        {
            pSpritebatch.Draw(texture, _position, Color.White);
        }
    }
}
