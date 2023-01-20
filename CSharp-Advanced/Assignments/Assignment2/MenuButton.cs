using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments.Assignment2
{
    internal class MenuButton : Button
    {
        public MenuButton(Texture2D pTexture)
        {
            _texture = pTexture;
        }

        public override void ButtonAction()
        {
            Game1.currentScene = Scenes.Menu;
            base.ButtonAction();
        }

        public override void Draw(SpriteBatch pSpritebatch)
        {
            pSpritebatch.Draw(_texture, position, buttonColor);
        }
    }
}
