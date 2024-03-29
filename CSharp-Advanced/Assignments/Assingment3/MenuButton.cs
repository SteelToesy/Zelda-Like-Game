﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments.Assignment3
{
    internal class MenuButton : Button
    {
        private SceneManager _sceneManager;
        public MenuButton(Vector2 pPosition,Texture2D pTexture, SceneManager pSceneManager) : base(pPosition)
        {
            _sceneManager = pSceneManager;
            position = pPosition;
            _texture = pTexture;
        }

        public override void ButtonAction()
        {
            _sceneManager.LoadScene(SceneTypes.Menu);
            base.ButtonAction();
        }

        public override void Draw(SpriteBatch pSpritebatch)
        {
            pSpritebatch.Draw(_texture, position, buttonColor);
        }
    }
}
