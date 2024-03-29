﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Assignments.Assignment1
{
    internal class Gate : GameObject
    {
        public Gate(Texture2D texture) : base("gate", new Vector2(400, 200), texture)
        {
        }
        public override void Update(GameTime pGameTime, List<GameObject> pGameObjects)
        {
            base.Update(pGameTime, pGameObjects);
        }
        public override void OnCollision(List<GameObject> pGameObjects)
        {
            if (this.collisionBox.Intersects(pGameObjects[0].collisionBox))
                Environment.Exit(0);
        }
    }
}
