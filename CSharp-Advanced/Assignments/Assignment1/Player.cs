using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Net.Mime;

namespace Assignments.Assignment1
{
    internal class Player : GameObject 
    {
        private int _playerSpeed;
        public Player() : base("Player", new Vector2(100, 100))
        {

        }

        protected override void Update(GameTime gameTime)
        {

            base.Update(gameTime);  
        }


        protected override void Draw(SpriteBatch spritebatch)
        {
            base.Draw(spritebatch);
        }
    }
}
