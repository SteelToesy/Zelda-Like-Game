using Assignments.Assignment1;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Assignments.Assignment2
{
    internal class Gate : GameObject
    {
        private Scenes _Scene;
        private GameObject _player;
        public Gate(Texture2D texture, GameObject player, Scenes scene) : base ("Gate")
        {
            _Scene = scene;
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
                Game1.currentScene = _Scene;
        }
        public override void Draw(SpriteBatch pSpritebatch)
        {
            pSpritebatch.Draw(_texture, position, Color.White);
        }
    }
}
