using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using cocoban.Components;

namespace cocoban.Components
{
    abstract class Sprite
    {
        public Vector2 currentPosition;
        public Vector2 previousPosition;

        protected SpriteBatch spriteBatch;
        protected Texture2D texture;  
        protected int frameWidth;
        protected int frameHeight;
        protected float scale;

        protected Point tileMapIntitialPosition;

        public Texture2D TextureBox
        {
            get => texture;
            private set => texture = value;
        }
        public SpriteBatch SpriteBatch
        {
            get => spriteBatch;
            private set => spriteBatch = value;
        }
        public Point TileMapInitialPosition
        {
            get => tileMapIntitialPosition;
            set => tileMapIntitialPosition = value;
        }
        public Vector2 CurrentPosition
        {
            get => currentPosition;
            set => currentPosition = value;
        }
        public Vector2 PreviousPosition
        {
            get => previousPosition;
            set => previousPosition = value;
        }
        public Rectangle CurrentPositionRectangle
        {   
            get => new Rectangle((int)(currentPosition.X), (int)(currentPosition.Y), (int)(frameWidth * scale), (int)(frameHeight * scale));
        }

        public Sprite(Texture2D texture, Vector2 currentPosition, SpriteBatch spriteBatch)
        {   
            this.texture = texture;
            this.currentPosition.X = currentPosition.X;
            this.currentPosition.Y = currentPosition.Y;
            this.previousPosition = currentPosition;
            this.spriteBatch = spriteBatch;
        }

        public Sprite(Texture2D texture, SpriteBatch spriteBatch)
        {
            this.texture = texture;
            this.previousPosition = currentPosition;
            this.spriteBatch = spriteBatch;
        }

        public abstract void Draw();
    }
}
