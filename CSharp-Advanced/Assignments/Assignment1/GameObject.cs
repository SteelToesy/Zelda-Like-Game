using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Assignments.Assignment1
{
    public class GameObject
    {
        protected string _name;
        protected Vector2 _position;
        protected Texture2D _texture;
        public GameObject(string pName, Vector2 pPosition, Texture2D pTexture)
        {
            _name = pName;
            _position = pPosition;
            _texture = pTexture;
        }
        
        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(_texture, _position, Color.White);
        }
    }
}
