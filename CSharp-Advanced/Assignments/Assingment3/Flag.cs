using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments.Assignment3
{
    internal class Flag : GameObject
    {
        public Flag(Vector2 pPosition, Texture2D pTexture) : base(pPosition, pTexture)
        {
            position= pPosition;
            _texture= pTexture;
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
