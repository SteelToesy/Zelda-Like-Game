using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments.Assignment1
{
    internal class Shield : GameObject
    {
        public Shield(Texture2D texture) : base("shield", new Vector2(600, 200), texture)
        {

        }
    }
}
