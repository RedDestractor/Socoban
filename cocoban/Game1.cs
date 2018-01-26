using cocoban.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace cocoban
{
    public class Cocoban : Game
    {
        private int currentLevel = 1;

        private readonly int songsNumber = 5;
        private readonly float speed = 3f;
        private readonly int period = 50;

        private bool haveToPause = false;        
        private float currentTime = 0f;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Color color = Color.ForestGreen;

        Player player;
        Boxes boxes;
        Board board;

        Song song;
        Song win;

        public int CurrentLevel
        {
            get => currentLevel;
            private set => currentLevel = value;
        }

        public Cocoban()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 865;
            graphics.PreferredBackBufferHeight = 720;
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            var texturePlayer = Content.Load<Texture2D>("player");
            var textureBox = Content.Load<Texture2D>("box");
            var textureWall = Content.Load<Texture2D>("tile");
            var textureEmpty = Content.Load<Texture2D>("grass");
            var textureHole = Content.Load<Texture2D>("hole");
            var winSoundEffect = Content.Load<Song>("win");

            song = ChooseMusic();
            win = winSoundEffect;

            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume = 0.5f;
            MediaPlayer.Play(song);

            board = new Board(textureWall, textureHole, textureEmpty, spriteBatch, Window, currentLevel);
            player = new Player(texturePlayer, spriteBatch, currentLevel, 0.7f);
            boxes = new Boxes(textureBox, spriteBatch, 10, currentLevel);

        }

        protected override void UnloadContent()
        {
            Content.Unload();
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            CheckGameStates(gameTime);

            player.Act(Window, gameTime, keyboardState, speed, period);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(color);

            spriteBatch.Begin(SpriteSortMode.BackToFront);

            base.Draw(gameTime);

            boxes.Draw();
            player.Draw();
            board.Draw();

            spriteBatch.End();
        }

        private Song ChooseMusic()
        {
            switch (currentLevel % songsNumber)
            {
                case 1:
                    return Content.Load<Song>("tetris");
                case 2:
                    return Content.Load<Song>("love");
                case 3:
                    return Content.Load<Song>("ghost");
                case 4:
                    return Content.Load<Song>("sw");
                case 5:
                    return Content.Load<Song>("cantina");
                case 6:
                    return Content.Load<Song>("nirvana");
            }
            return null;
        }

        private void CheckGameStates(GameTime gameTime)
        {         
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }
            if (boxes.HaveToGetNextLevel)
            {
                currentTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
                var pauseDuration = win.Duration.Seconds;
                if (!haveToPause)
                {
                    currentLevel++;
                    haveToPause = true;
                    MediaPlayer.Stop();
                    MediaPlayer.Play(win);
                }                
                if (currentLevel > MapStore.levelsNumber)
                {
                    Exit();
                }
                else if (currentTime >= pauseDuration)
                {
                    haveToPause = false;
                    currentTime -= pauseDuration;
                    UnloadContent();
                    LoadContent();
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                UnloadContent();
                LoadContent();
            }
        }
    }
}
