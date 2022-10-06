using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Assignments.Assignment1
{
    internal class Gate : GameObject
    {
        public Gate(Texture2D texture) : base("gate", new Vector2(400, 200), texture)
        {
        }
    }
}
