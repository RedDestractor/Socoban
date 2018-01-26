using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using cocoban.Components;

namespace cocoban.Components
{   
    class Boxes
    {
        private bool haveToGetNextLevel;
        private int holesNumber;
        private Texture2D textureBox;
        private SpriteBatch spriteBatch;
        private List<Box> boxes;
        private static Boxes currentList;

        private Random rnd = new Random();

        public static Boxes CurrentList
        {
            get => currentList;
            private set => currentList = value;
        }
        public Texture2D TextureBox
        {
            get => textureBox;
            private set => textureBox = value;
        }
        public SpriteBatch SpriteBatch
        {
            get => spriteBatch;
            private set => spriteBatch = value;
        }
        public List<Box> ListBoxes
        {
            get => boxes;
            private set => boxes = value;
        }
        public bool HaveToGetNextLevel
        {
            get => haveToGetNextLevel;
            private set => haveToGetNextLevel = value;
        }
        public int HolesNumber
        {
            get => holesNumber;
            private set => holesNumber = value;
        }

        public Boxes(Texture2D textureBox, SpriteBatch spriteBatch, int boxesNumber,int level)
        {
            this.boxes = new List<Box>(boxesNumber);
            this.textureBox = textureBox;
            this.spriteBatch = spriteBatch;
            this.holesNumber = MapStore.GetHolesNumber(MapStore.GetLevel(level));

            var tileMapIntitialPositions = MapStore.FindBoxesPositions(MapStore.GetLevel(level));

            foreach (var tilePoint in tileMapIntitialPositions)
            {
                boxes.Add(new Box(textureBox, 
                         new Vector2(Board.GetTileSize * tilePoint.X, Board.GetTileSize * tilePoint.Y),
                         spriteBatch, 0.47f)); 
            }

            CurrentList = this;
        }

        public void Draw()
        {   
            var countBoxCollisions = 0;
            foreach (var box in ListBoxes)
            {
                if (CollisionsChecker.HaveHoleCollisions(box))
                {
                    countBoxCollisions++;
                }
                box.Draw();
            }
            if (countBoxCollisions == HolesNumber)
                haveToGetNextLevel = true;

        }
    }
}
