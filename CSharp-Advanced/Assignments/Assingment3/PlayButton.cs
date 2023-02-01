using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments.Assignment3
{
    internal class PlayButton : Button
    {
        public PlayButton(Texture2D pTexture)
        {
            _texture = pTexture;
        }

        public override void ButtonAction()
        {
            //Game1.currentScene = Scenes.Level1;
            base.ButtonAction();
        }

        public override void Draw(SpriteBatch pSpritebatch)
        {
            pSpritebatch.Draw(_texture, position, buttonColor);
        }
    }
}
