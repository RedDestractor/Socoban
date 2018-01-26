using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace cocoban.Components
{
    class Board
    {
        private static readonly float scale = 0.3f;
        private static readonly int tileLength = 160;

        private Tile[,] tiles;

        private Texture2D emptyTexture;
        private Texture2D holeTexture;
        private Texture2D wallTexture;
        private SpriteBatch spriteBatch;

        private static Board currentBoard;

        private Random rnd = new Random();

        public SpriteBatch SpriteBatch
        {
            get => spriteBatch;
            private set => spriteBatch = value;
        }
        public static Board CurrentBoard
        {
            get => currentBoard;
            private set => currentBoard = value;
        }
        public Tile[,] Tiles
        {
            get => tiles;
            private set => tiles = value;
        }
        static public float GetTileSize
        {
            get =>  tileLength * scale;
        }
        public Texture2D WallTexture
        {
            get => wallTexture;
            private set => wallTexture = value;
        }
        public Texture2D EmptyTexture
        {
            get => emptyTexture;
            private set => emptyTexture = value;
        }
        public Texture2D HoleTexture
        {
            get => holeTexture;
            private set => holeTexture = value;
        }

        public Board(Texture2D wallTexture, Texture2D holeTexture, Texture2D emptyTexture, 
                    SpriteBatch spriteBatch, GameWindow game, int level)
        {
            this.wallTexture = wallTexture;
            this.holeTexture = holeTexture;
            this.emptyTexture = emptyTexture;
            this.spriteBatch = spriteBatch;
            this.tiles = InitiateBoard(scale, level);
            currentBoard = this;
        }

        private Tile[,] InitiateBoard(float scale, int levelNumber)
        {
            var tiles = new Tile[MapStore.rowsTilesNumber, MapStore.columnsTilesNumber];
            var level = MapStore.GetLevel(levelNumber).ToCharArray();
            var k = 0;

            for (var y = 0; y < MapStore.rowsTilesNumber; y++)
            {
                for (var x = 0; x < MapStore.columnsTilesNumber; x++)
                {
                    var position = new Vector2(tileLength * x * scale, tileLength * y * scale);
                    if (level[k] == 'W')
                    {
                        tiles[y, x] = new Wall(wallTexture, position, spriteBatch, scale);
                    }
                    else if (level[k] == 'H')
                    {
                        tiles[y, x] = new Hole(holeTexture, position, spriteBatch, scale);
                    }
                    else
                    {
                        tiles[y, x] = new Empty(emptyTexture, position, spriteBatch, scale);
                    }
                    k++;
                }
            }

            return tiles;
        }

        public void Draw()
        {
            foreach (var tile in tiles)
            {
                tile.Draw();
            }
        }
    }
}
