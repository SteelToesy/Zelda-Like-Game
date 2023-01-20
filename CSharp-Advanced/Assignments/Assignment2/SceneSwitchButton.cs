using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments.Assignment2
{
    internal class SceneSwitchButton : Button
    {
        private readonly Scenes _scene;
        public SceneSwitchButton(Texture2D pTexture, Scenes pScene)
        {
            _scene = pScene;    
            _texture = pTexture;
        }

        public override void ButtonAction()
        {
            Game1.currentScene = _scene;
            base.ButtonAction();
        }

        public override void Draw(SpriteBatch pSpritebatch)
        {
            pSpritebatch.Draw(_texture, position, buttonColor);
        }

        //public override void Update(GameTime gameTime)
        //{
        //    Console.WriteLine("current Scene = " + Game1.currentScene);
        //    Console.WriteLine("Button goes towards " + _scene);
        //    base.Update(gameTime);
        //}
    }
}
