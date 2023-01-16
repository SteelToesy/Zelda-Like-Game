using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignments.AssignmentDion
{
    internal class Player : GameObject 
    {
        // array of textures to switch between textures
        public Player()
        {

        }

        public override void Update()
        {
            // Normailized movement
            //Vector2 movement = Vector2.Zero;
            //if (Keyboard.GetState().IsKeyDown(Keys.W))
            //    movement.Y -= 1;
            //if (Keyboard.GetState().IsKeyDown(Keys.S))
            //    movement.Y += 1;
            //if (Keyboard.GetState().IsKeyDown(Keys.A))
            //    movement.X -= 1;
            //if (Keyboard.GetState().IsKeyDown(Keys.D))
            //    movement.X += 1;
            //if (movement != Vector2.Zero)
            //    movement.Normalize();
            //_position = new Vector2(_position.X + movement.X * _speed, _position.Y + movement.Y * _speed);
        }
        public override void Draw()
        {

        }
    }
}
