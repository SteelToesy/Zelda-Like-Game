using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Assignments.Assignment2
{
    internal class Shield : GameObject
    {
        public Shield(Texture2D texture) : base("shield", new Vector2(600, 200), texture)
        {

        }
        public override void Update(GameTime pGameTime, List<GameObject> pGameObjects)
        {
            base.Update(pGameTime, pGameObjects);
        }
        public override void OnCollision(List<GameObject> pGameObjects)
        {
            if (this.collisionBox.Intersects(pGameObjects[0].collisionBox))
            {
                if (pGameObjects[0].textureIndexer == (int)Texture.PlayerWithWeapon)
                    pGameObjects[0].textureIndexer = (int)Texture.PlayerWithWeaponAndShield;
                else
                    pGameObjects[0].textureIndexer = (int)Texture.PlayerWithShield;
                enabled = false;
            }
        }
    }
}
