﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Assignments.Assignment2
{
    internal class PlayButton : Button
    {
        public PlayButton(Texture2D pTexture)
        {
            _texture = pTexture;
        }

        public override void ButtonAction()
        {
            SceneManager.currentScene = Scenes.Level1;
            base.ButtonAction();
        }

        public override void Draw(SpriteBatch pSpritebatch)
        {
            pSpritebatch.Draw(_texture, position, buttonColor);
        }
    }
}
