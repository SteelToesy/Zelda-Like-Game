using Assignments.Assignment1;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Assignments.Assignment2
{
    internal class Gate : GameObject
    {
        private Texture2D _texture;
        public Gate(Texture2D texture) : base("gate", new Vector2(400, 200), texture)
        {
            _texture = texture;
        }
        public override void Update(GameTime pGameTime, List<GameObject> pGameObjects)
        {
            base.Update(pGameTime, pGameObjects);
        }
        public override void OnCollision(List<GameObject> pGameObjects)
        {
            // If the player collides with the gate, the game ends
            if (this.collisionBox.Intersects(pGameObjects[0].collisionBox))
                Environment.Exit(0);
        }
        public override void Draw(SpriteBatch pSpritebatch)
        {
            pSpritebatch.Draw(_texture, _position, Color.White);
        }
    }
}
