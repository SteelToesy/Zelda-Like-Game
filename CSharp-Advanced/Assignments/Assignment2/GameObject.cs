using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Assignments.Assignment2
{
    public class GameObject
    {
        private readonly Texture2D _texture;

        protected string _name;
        protected Vector2 _position;
        
        public bool enabled = true;
        public int textureIndexer = 0;
        
        public Rectangle collisionBox
        {
            get => new((int)_position.X, (int)_position.Y, _texture.Width, _texture.Height);
        }
        
        public GameObject(string pName, Vector2 pPosition, params Texture2D[] pTextures)
        {
            _name = pName; 
            _position = pPosition;
            _texture = pTextures[textureIndexer];
        }
        
        public virtual void Update(GameTime pGameTime, List<GameObject> pGameObjects)
        {
            OnCollision(pGameObjects);
        }

        public virtual void Draw(SpriteBatch pSpritebatch)
        { 
            
        }

        public virtual void OnCollision(List<GameObject> pGameObject)
        {
            
        }
    }
}

