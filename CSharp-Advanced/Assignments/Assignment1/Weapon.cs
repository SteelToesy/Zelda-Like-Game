using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Assignments.Assignment1
{
    internal class Weapon : GameObject
    {
        public Weapon(Texture2D texture) : base("weapon", new Vector2(100, 200), texture)
        {
            
        }
    }
}
