using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Assignments.Assignment1
{
    internal class Player : GameObject 
    {
        private float _speed = 5f;

        public Player(params Texture2D[] textures) : base("player", new Vector2(400, 400), textures)
        {
            
        }

        public override void Update(GameTime pGameTime, List<GameObject> gameObjects, List<Texture2D> pTextures)
        {

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


            base.Update(pGameTime, gameObjects, pTextures);  
        }
    }
}
