using Assignments.Assignment3;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;


namespace Assignments.Assingment3
{
    public class HealthBar : GameObject
    {
        public int health;

        public Texture2D texture
        {
            get => _textures[health - 1];
        }

        public HealthBar(Vector2 pPosition, params Texture2D[] pHealthStates) : base(pPosition, pHealthStates)
        {
            _textures = pHealthStates.ToList();
            health = 3;
            position = pPosition;
        }

        public override void Update(GameTime pGameTime)
        {
            base.Update(pGameTime);
        }

        public override void Draw(SpriteBatch pSpritebatch)
        {
            pSpritebatch.Draw(texture, position, Color.White);
            base.Draw(pSpritebatch);
        }
    }
}
