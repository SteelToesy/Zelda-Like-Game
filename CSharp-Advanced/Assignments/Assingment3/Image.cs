using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Assignments.Assignment3
{
    internal class Image : GameObject
    {
        public Image(Vector2 pPosition,Texture2D pTexture) : base(pPosition)
        {
            position = pPosition;
            _texture = pTexture;
        }

        public override void Update(GameTime pGameTime)
        {
            base.Update(pGameTime);
        }

        public override void Draw(SpriteBatch pSpritebatch)
        {
            pSpritebatch.Draw(_texture, position, Color.White);
        }
    }
}
