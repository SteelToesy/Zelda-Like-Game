using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Assignments.Assignment1
{
    public class GameObject
    {
        protected string _name;
        protected Vector2 _position;
        public GameObject(string pName, Vector2 pPosition)
        {
            _name = pName;
            _position = pPosition;
        }
        protected virtual void Update(GameTime gameTime)
        {

        }

        protected virtual void Draw(SpriteBatch spritebatch)
        {
            
        }
    }
}
