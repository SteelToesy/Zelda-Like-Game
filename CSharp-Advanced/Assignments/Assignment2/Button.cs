using Assignments.Assignment1;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Assignments.Assignment2
{
    enum ButtonStates
    {
        none,
        hover,
        pressed
    }

    internal class Button : GameObject
    {
        protected ButtonStates state;
        protected Color buttonColor;
        public Button() : base("Button")
        {

        }

        public override void Update(GameTime pGameTime)
        {
            var mouseState = Mouse.GetState();
            var mousePoint = new Point(mouseState.X, mouseState.Y);

            switch (state)
            {
                case ButtonStates.none :
                {
                    buttonColor = Color.White;
                    if (collisionBox.Contains(mousePoint))
                        state= ButtonStates.hover;
                    break;
                }
                case ButtonStates.hover:
                {
                    buttonColor= Color.Gray;
                    if (mouseState.LeftButton == ButtonState.Pressed)
                        state= ButtonStates.pressed;
                    else if (!collisionBox.Contains(mousePoint))
                        state = ButtonStates.none;
                    break;
                }
                case ButtonStates.pressed:
                {
                    buttonColor = Color.Red;
                    if (mouseState.LeftButton == ButtonState.Released && collisionBox.Contains(mousePoint))
                    {
                        state = ButtonStates.none; 
                        ButtonAction();
                    }
                    else if (mouseState.LeftButton == ButtonState.Released && !collisionBox.Contains(mousePoint))
                        state = ButtonStates.none;
                    break;
                }
            }
            base.Update(pGameTime);
        }   

        public virtual void ButtonAction()
        {

        }
    }
}
