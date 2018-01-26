using cocoban.Components;

namespace cocoban
{
    static class CollisionsChecker
    {   
        private const int approximation = 20;

        static public bool HaveCollisionWithPlayer(Sprite player, Sprite box)
        {
            return player.CurrentPositionRectangle.Intersects(box.CurrentPositionRectangle);
        }

        static public bool HaveBoardAndBoxesCollisions(Sprite sprite)
        {
            return HaveBoardCollisions(sprite) || HaveBoxesCollisions(sprite);
        }

        static private bool HaveBoardCollisions(Sprite sprite)
        {
            foreach (var tile in Board.CurrentBoard.Tiles)
            {
                if ((tile is Wall) && tile.CurrentPositionRectangle.Intersects(sprite.CurrentPositionRectangle))
                {
                    return true;
                }
            }
            return false;
        }

        static public bool HaveBoxesCollisions(Sprite sprite)
        {
            foreach (var box in Boxes.CurrentList.ListBoxes)
            {
                if (sprite == box) continue;
                if (box.CurrentPositionRectangle.Intersects(sprite.CurrentPositionRectangle))
                {
                    return true;
                }
            }
            return false;
        }

        static public bool HaveHoleCollisions(Sprite sprite)
        {
            foreach (var tile in Board.CurrentBoard.Tiles)
            {
                if (tile is Hole)
                {
                    if (tile.CurrentPositionRectangle.Intersects(sprite.CurrentPositionRectangle) &&
                        tile.CurrentPositionRectangle.Left - approximation < sprite.CurrentPositionRectangle.Left &&
                        tile.CurrentPositionRectangle.Right + approximation > sprite.CurrentPositionRectangle.Right &&
                        tile.CurrentPositionRectangle.Top - approximation < sprite.CurrentPositionRectangle.Top &&
                        tile.CurrentPositionRectangle.Bottom + approximation > sprite.CurrentPositionRectangle.Bottom)
                        return true;
                }
            }
            return false;
        }
    }
}


