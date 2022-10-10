using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Assignments.Assignment1
{
    internal class Weapon : GameObject
    {
        public Weapon(Texture2D texture) : base("weapon", new Vector2(100, 200), texture)
        {

        }

        public override void Update(GameTime pGameTime, List<GameObject> pGameObjects, List<Texture2D> pTextures)
        {
            base.Update(pGameTime, pGameObjects, pTextures);
        }

        public override void OnCollision(List<GameObject> pGameObjects)
        {
            if (this.collisionBox.Intersects(pGameObjects[0].collisionBox))
            {
                if (pGameObjects[0].textureIndexer == 1)
                    pGameObjects[0].textureIndexer = 3;
                else
                    pGameObjects[0].textureIndexer = 2;
                enabled = false;
            }
        }
    }
}
