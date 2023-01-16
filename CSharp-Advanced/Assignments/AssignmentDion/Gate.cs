using Assignments.Assignment1;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Assignments.AssignmentDion
{
    internal class Gate : GameObject
    {
        public Gate()
        {

        }
        public override void Update()
        {
        }
        public override void OnCollision()
        {
            // If the player collides with the gate, the game ends
            //if (this.collisionBox.Intersects(pGameObjects[0].collisionBox))
            //    Environment.Exit(0);
        }

        public override void Draw()
        {

        }
    }
}
