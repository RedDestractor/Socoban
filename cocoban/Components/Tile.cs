using System;
using cocoban.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace cocoban.Components
{   
    class Tile : Sprite
    {
        public Tile(Texture2D texture, Vector2 currentPosition, SpriteBatch spriteBatch, float scale)
            : base (texture, currentPosition, spriteBatch)
        {   
            this.scale = scale;
            frameWidth = texture.Width;
            frameHeight = texture.Height;
        }

        public override void Draw()
        {
            spriteBatch.Draw(texture: texture, destinationRectangle: CurrentPositionRectangle, color: Color.White, layerDepth: 1);
        }
    }
}
