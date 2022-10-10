using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Assignments.Assignment1
{
    internal class Shield : GameObject
    {
        public Shield(Texture2D texture) : base("shield", new Vector2(600, 200), texture)
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
                if (pGameObjects[0].textureIndexer == 2)
                    pGameObjects[0].textureIndexer = 3;
                else
                    pGameObjects[0].textureIndexer = 1;
                enabled = false;
            }
        }
    }
}
