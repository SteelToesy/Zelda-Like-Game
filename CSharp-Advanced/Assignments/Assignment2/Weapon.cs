using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Assignments.Assignment2
{
    internal class Weapon : GameObject
    {
        Player _player;
        
        public Weapon(Texture2D texture, Player pPlayer) : base("weapon", new Vector2(100, 200), texture)
        {
            _player = pPlayer;
        }

        public override void Update(GameTime pGameTime, List<GameObject> pGameObjects)
        {
            base.Update(pGameTime, pGameObjects);
        }

        public override void OnCollision(List<GameObject> pGameObjects)
        {
            if(collisionBox.Intersects(_player.collisionBox))
            {
                if (_player.textureIndexer == (int)Texture.PlayerWithShield)
                    _player.textureIndexer = (int)Texture.PlayerWithWeaponAndShield;
                else
                    _player.textureIndexer = (int)Texture.PlayerWithWeapon;
                enabled = false;
            }   
            

            //if (this.collisionBox.Intersects(pGameObjects[0].collisionBox))
            //{
            //    if (pGameObjects[0].textureIndexer == (int)Texture.PlayerWithShield)
            //        pGameObjects[0].textureIndexer = (int)Texture.PlayerWithWeaponAndShield;
            //    else
            //        pGameObjects[0].textureIndexer = (int)Texture.PlayerWithWeapon;
            //    enabled = false;
            //}
        }
    }
}
