using Assignments.Assignment1;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Assignments.AssignmentDion
{
    internal class Weapon : GameObject
    {


        public Weapon()
        {

        }

        public override void Update()
        {
        }

        public override void OnCollision()
        {
            // If the player collides with the weapon, the player gets the weapon   
            //if (collisionBox.Intersects(_player.collisionBox))
            //{
            //    if (_player.textureIndexer == (int)PlayerTexture.PlayerWithShield)
            //        _player.textureIndexer = (int)PlayerTexture.PlayerWithWeaponAndShield;
            //    else
            //        _player.textureIndexer = (int)PlayerTexture.PlayerWithWeapon;
            //    enabled = false;
            //}
        }
        public override void Draw()
        {

        }
    }
}
