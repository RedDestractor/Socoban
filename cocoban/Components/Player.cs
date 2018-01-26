using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using cocoban.Components;

namespace cocoban
{
    class Player : Sprite
    {
        const int frameWidthPlayer = 48;
        const int frameWidthHeight = 48;
        const int approximation = 6;

        private readonly Point spriteSize = new Point(4, 4);
        private static int currentTime;
        protected Point currentFrame = new Point(0, 0);

        public Point CurrentFrame
        {
            get => currentFrame;
            private set => currentFrame = value;
        }
        public Rectangle FrameRectangle
        {
            get => new Rectangle((int)(CurrentFrame.X * frameWidth + approximation),
                                (int)(CurrentFrame.Y * frameHeight + approximation), 
                                (int)(frameWidth - approximation * 2), (int)(frameHeight - approximation * 2));
        }

        static Player()
        {
            currentTime = 0;
        }
        public Player(Texture2D texture, SpriteBatch spriteBatch, int level,  float scale = 1f)
            : base (texture, spriteBatch)
        {
            var tileMapIntitialPosition = MapStore.FindPlayerPosition(MapStore.GetLevel(level));

            this.currentPosition.X = Board.GetTileSize * tileMapIntitialPosition.X;
            this.currentPosition.Y = Board.GetTileSize * tileMapIntitialPosition.Y;
            this.frameWidth = frameWidthPlayer;
            this.frameHeight = frameWidthHeight;
            this.scale = scale;
        }            
  
        public void Act(GameWindow game, GameTime gameTime, KeyboardState keyboardState, float speed, int period)
        {
            if (keyboardState.IsKeyDown(Keys.Left))
            {
                TryGoAndMoveBoxes(game, Keys.Left, keyboardState, speed, gameTime, ref currentTime);
                if (currentTime > period)
                {
                    ChangeFrame(1, ref currentTime);
                }
            }
            else if (keyboardState.IsKeyDown(Keys.Right))
            {
                TryGoAndMoveBoxes(game, Keys.Right, keyboardState, speed, gameTime, ref currentTime);
                if (currentTime > period)
                {
                    ChangeFrame(3, ref currentTime);
                }
            }
            else if (keyboardState.IsKeyDown(Keys.Up))
            {
                TryGoAndMoveBoxes(game, Keys.Up, keyboardState, speed, gameTime, ref currentTime);
                if (currentTime > period)
                {
                    ChangeFrame(2, ref currentTime);
                }
            }
            else if (keyboardState.IsKeyDown(Keys.Down))
            {
                TryGoAndMoveBoxes(game, Keys.Down, keyboardState, speed, gameTime, ref currentTime);
                if (currentTime > period)
                {
                    ChangeFrame(0, ref currentTime);
                }
            }
        }

        private void TryGoAndMoveBoxes(GameWindow game, Keys key, KeyboardState keyboardState, float speed, GameTime gameTime, ref int currentTime)
        {
            currentTime += gameTime.ElapsedGameTime.Milliseconds;

            if (key == Keys.Down && currentPosition.Y < game.ClientBounds.Height - CurrentPositionRectangle.Height)
            {
                previousPosition = currentPosition;
                currentPosition.Y += speed;
            }
            else if (key == Keys.Up && currentPosition.Y > 0)
            {
                previousPosition = currentPosition;
                currentPosition.Y -= speed;
            }
            else if (key == Keys.Left && currentPosition.X > 0)
            {
                previousPosition = currentPosition;
                currentPosition.X -= speed;
            }
            else if (key == Keys.Right && currentPosition.X < game.ClientBounds.Width - CurrentPositionRectangle.Width)
            {
                previousPosition = currentPosition;
                currentPosition.X += speed;
            }

            MoveBoxesIfPossible(game, gameTime, keyboardState, speed);
            
            if (CollisionsChecker.HaveBoardAndBoxesCollisions(this))
            {   
                currentPosition.Y = previousPosition.Y;
                currentPosition.X = previousPosition.X;
            }
        }

        private void MoveBoxesIfPossible (GameWindow game, GameTime gameTime, KeyboardState keyboardState, float speed)
        {
            foreach (var box in Boxes.CurrentList.ListBoxes)
            {   
                if (CollisionsChecker.HaveCollisionWithPlayer(this, box))
                MoveBox(box, game, gameTime, keyboardState, speed);
                CollisionsChecker.HaveHoleCollisions(box);
            }
        }

        private void MoveBox(Box box, GameWindow game, GameTime gameTime, KeyboardState keyboardState, float speed)
        {   
            if (keyboardState.IsKeyDown(Keys.Left) &&
               box.currentPosition.X > 0)
            {
                box.PreviousPosition = box.CurrentPosition;
                box.currentPosition.X -= speed;
            }
            else if (keyboardState.IsKeyDown(Keys.Right) &&
                    box.currentPosition.X < game.ClientBounds.Width - box.CurrentPositionRectangle.Width)
            {
                box.previousPosition = box.currentPosition;
                box.currentPosition.X += speed;
            }
            else if (keyboardState.IsKeyDown(Keys.Up) &&
                    box.currentPosition.Y > 0)
            {
                box.previousPosition = box.currentPosition;
                box.currentPosition.Y -= speed;
            }
            else if (keyboardState.IsKeyDown(Keys.Down) &&
                    box.currentPosition.Y < game.ClientBounds.Height - box.CurrentPositionRectangle.Height)
            {
                box.previousPosition = box.currentPosition;
                box.currentPosition.Y += speed;
            }

            if (CollisionsChecker.HaveBoardAndBoxesCollisions(box))
            {
                box.currentPosition.Y = box.previousPosition.Y;
                box.currentPosition.X = box.previousPosition.X;
            }
        }

        private void ChangeFrame(int frameX, ref int currentTime)
        {
            currentTime = 0;

            currentFrame.X = frameX;
            ++currentFrame.Y;
            if (currentFrame.Y >= spriteSize.Y)
            {
                currentFrame.Y = 0;
            }
        }

        public override void Draw()
        {
            spriteBatch.Draw(texture, CurrentPositionRectangle, FrameRectangle, Color.White);
        }
    }
}
