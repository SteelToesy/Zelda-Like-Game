using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Net.Mime;

namespace Assignments.Assignment1
{
    internal class Player : GameObject 
    {
        private float _speed = 2f;
        
        public Player(Texture2D texture) : base("player", new Vector2(400, 400), texture)
        {
            
        }

        public override void Update(GameTime gameTime)
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


            base.Update(gameTime);  
        }
    }
}
