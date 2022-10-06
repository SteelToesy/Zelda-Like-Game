using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assignments.Assignment1
{
    internal class Weapon : GameObject
    {

        public Weapon(Texture2D texture) : base("weapon", new Vector2(100, 200), texture)
        {

        }
        
        public override void Update(GameTime pGameTime, List<GameObject> gameObjects)
        {
            if (this.collisionBox.Intersects(gameObjects[0].collisionBox))
            {
                Console.WriteLine("Collision with weapon");
            }
            base.Update(pGameTime, gameObjects);
        }
    }
}
