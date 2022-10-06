using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Assignments.Assignment1
{
    public class GameObject
    {
        protected string _name;
        protected Vector2 _position;
        protected Texture2D _texture;
        public Rectangle collisionBox
        {
            get
            {
                  return new Rectangle((int)_position.X, (int)_position.Y, _texture.Width, _texture.Height);
            }
        }
        public GameObject(string pName, Vector2 pPosition, Texture2D pTexture)
        {
            _name = pName;
            _position = pPosition;
            _texture = pTexture;
        }
        
        public virtual void Update(GameTime pGameTime, List<GameObject> gameObjects)
        {
        }

        public virtual void Draw(SpriteBatch pSpritebatch)
        {
            pSpritebatch.Draw(_texture, _position, Color.White);
        }

        public bool CheckCollision(GameObject pGameObject)
        {
            return collisionBox.Intersects(pGameObject.collisionBox);
        }
    }
}
