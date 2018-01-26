using System;
using cocoban.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace cocoban.Components
{
    class Empty : Tile
    {
        public Empty(Texture2D texture, Vector2 currentPosition, SpriteBatch spriteBatch, float scale) 
            : base(texture, currentPosition, spriteBatch, scale)
        {

        }
    }
}
