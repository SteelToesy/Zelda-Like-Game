using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Assignments.Assignment2
{
    public enum Texture
    {
        Player,
        PlayerWithShield,
        PlayerWithWeapon,
        PlayerWithWeaponAndShield,
        Shield,
        Weapon,
        Gate
    }

    public class GameObject
    {
        protected string _name;
        protected Vector2 _position;
        protected Texture2D _texture;

        protected List<Texture2D> _textures = new List<Texture2D>();

        public int textureIndexer = 0;
        public bool enabled = true;

        public Texture2D texture
        {
            get => _textures[textureIndexer];
        }

        public Rectangle collisionBox
        {
            get => new Rectangle((int)_position.X, (int)_position.Y, texture.Width, texture.Height);
        }
        
        public GameObject(string pName, Vector2 pPosition, params Texture2D[] pTextures)
        {
            _name = pName; 
            _position = pPosition;
            _textures = new List<Texture2D>(pTextures);
        }
        
        public virtual void Update(GameTime pGameTime, List<GameObject> pGameObjects)
        {
            OnCollision(pGameObjects);
        }

        public virtual void Draw(SpriteBatch pSpritebatch)
        { 
            pSpritebatch.Draw(texture, _position, Color.White);
        }

        public virtual void OnCollision(List<GameObject> pGameObject)
        {
            
        }
    }
}

