using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using cocoban.Components;

namespace cocoban
{
    class Box : Sprite
    {
        public Box(Texture2D texture, Vector2 currentPosition, SpriteBatch spriteBatch, float scale)
            : base(texture, currentPosition, spriteBatch)
        {   
            this.scale = scale;
            frameWidth = texture.Width;
            frameHeight = texture.Height;
        }

        public override void Draw()
        {
            spriteBatch.Draw(texture, CurrentPositionRectangle, Color.White);
        }
    }
}
