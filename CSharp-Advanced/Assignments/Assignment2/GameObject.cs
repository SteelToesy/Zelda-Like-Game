using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Assignments.Assignment2
{
    public class GameObject
    {
        protected Texture2D _texture;
        protected List<Texture2D> _textures = new List<Texture2D>();

        protected string _name;
        public Vector2 position;

        public int textureIndexer = 0;

        public bool active = true;
        
        public Rectangle collisionBox
        {
            get => new((int)position.X, (int)position.Y, _texture.Width, _texture.Height);
        }
        
        public GameObject(string pName, params Texture2D[] pTextures)
        {

        }
        
        public virtual void Update(GameTime pGameTime)
        {
            OnCollision();
        }

        public virtual void Draw(SpriteBatch pSpritebatch)
        { 
            
        }

        public virtual void OnCollision()
        {
            
        }
    }
}

