using Assignments.Assignment1;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Assignments.AssignmentDion
{
    internal class Shield : GameObject
    {

        public Shield()
        {

        }
        public override void Update()
        {
        }
        public override void OnCollision()
        {
            // If the player collides with the shield, the player gets the shield
            //if (this.collisionBox.Intersects(pGameObjects[0].collisionBox))
            //{
            //    if (_player.textureIndexer == (int)PlayerTexture.PlayerWithWeapon)
            //        _player.textureIndexer = (int)PlayerTexture.PlayerWithWeaponAndShield;
            //    else
            //        _player.textureIndexer = (int)PlayerTexture.PlayerWithShield;
            //    enabled = false;
            //}
        }
        public override void Draw()
        {

        }
    }
}
