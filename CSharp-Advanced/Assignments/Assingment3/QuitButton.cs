using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments.Assignment3
{
    internal class QuitButton : Button
    {
        public QuitButton(Texture2D pTexture) 
        {
            _texture = pTexture;
        }
        public override void ButtonAction()
        {
            Environment.Exit(0);
            base.ButtonAction();
        }
        public override void Draw(SpriteBatch pSpritebatch)
        {
            pSpritebatch.Draw(_texture, position, buttonColor);
        }
    }
}
