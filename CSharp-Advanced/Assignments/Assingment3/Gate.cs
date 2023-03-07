using Assignments.Assignment1;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Assignments.Assignment3
{
    internal class Gate : GameObject
    {
        private SceneManager _sceneManager;
        private SceneTypes _Scene;
        private GameObject _player;
        public Gate(Vector2 pPosition, Texture2D texture, GameObject player, SceneTypes scene, SceneManager sceneManager) : base(pPosition)
        {
            position = pPosition;
            _Scene = scene;
            _player = player;
            _texture = texture;
            _sceneManager = sceneManager;
        }
        public override void Update(GameTime pGameTime)
        {
            base.Update(pGameTime);
        }
        public override void OnCollision()
        {
            if (this.collisionBox.Intersects(_player.collisionBox))
            {
                _sceneManager.LoadScene(_Scene);
            }
        }
        public override void Draw(SpriteBatch pSpritebatch)
        {
            pSpritebatch.Draw(_texture, position, Color.White);
        }
    }
}
