using Assignments.Assignment1;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Assignments.Assignment2
{
    internal class Gate : GameObject
    {
        private Player _player;
        public Gate(Texture2D texture, Player player) : base ("Gate")
        {
            _player = player;
            _texture = texture;
        }
        public override void Update(GameTime pGameTime)
        {
            base.Update(pGameTime);
        }
        public override void OnCollision()
        {
            // If the player collides with the gate, the game ends
            // TODO make it so that it changes scene
            if (this.collisionBox.Intersects(_player.collisionBox))
                Environment.Exit(0);
        }
        public override void Draw(SpriteBatch pSpritebatch)
        {
            pSpritebatch.Draw(_texture, position, Color.White);
        }
    }
}
