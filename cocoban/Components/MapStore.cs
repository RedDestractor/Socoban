using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cocoban.Components
{
    static class MapStore
    {   
        static public readonly int columnsTilesNumber = 18;
        static public readonly int rowsTilesNumber = 15;
        static public readonly int levelsNumber = 6;

        static private string Level1 = "EEEEEEEEEEEEEEEEEE" +
                                       "EEEEEEEEEEEEEEEEEE" +
                                       "EEEEEEEEEEEEEEEEEE" +
                                       "EPEEEEEEBEEEEEEEHE" +
                                       "EEEEEEEEBEEEEEEEHE" +
                                       "EEEEEEEEBEEEEEEEHE" +
                                       "EEEEEEEEBEEEEEEEHE" +
                                       "EEEEEEEEEEEEEEEEEE" +
                                       "EEEEEEEEEEEEEEEEEE" +
                                       "EEEEEEEEEEEEEEEEEE" +
                                       "EEEEEEEEEEEEEEEEEE" +
                                       "EEEEEEEEEEEEEEEEEE" +
                                       "EEEEEEEEEEEEEEEEEE" +
                                       "EEEEEEEEEEEEEEEEEE" +
                                       "EEEEEEEEEEEEEEEEEE";

        static private string Level5 =
                                       "EEEWWWWWWEEEEEEEEE" +
                                       "EEEWPEEEWWWEEEEEEE" +
                                       "EEWWBBBBEEWEEEEEEE" +
                                       "EWWHEEEEWBWWEEEEEE" +
                                       "EWEBWHBBWHEWWWEEEE" +
                                       "EWEEHHWHHBEHEWEEEE" +
                                       "EWWBWHEHHHBHWWEEEE" +
                                       "EWHEBHBWWBWWWEEEEW" +
                                       "EWEEEBEBEEWEEEEEEW" +
                                       "EWWWEEEEEWWEEEEEEW" +
                                       "EEEWWWWHWWEEEEEEEW" +
                                       "EEEEEEWWWEEEEEEWWW" +
                                       "EEEEEEEEEEEEEWWWWW" +
                                       "EEEEEEEEEEEWWWWWWW" +
                                       "EEEEEEEEEWWWWWWWWW";

        static private string Level4 = "EEEEEEWWWWWWWWWWWW" +
                                       "EEEEEEEBEEEEBEEEEW" +
                                       "EEEWWWWBWWEEWWWWEW" +
                                       "EEEEEEEEWEEEEWHHHW" +
                                       "EWEWWEEEWEEEEWHHHW" +
                                       "EWEWEEEEWEBWWWHHHW" +
                                       "EWEWWWWWWBEWWWHHHW" +
                                       "EWEWWWEEBEEWWWEEEW" +
                                       "EWBWPEEBBEEEBEEEEW" +
                                       "EEEWEEEEBWEBEEEEEW" +
                                       "EEEEEEEEEWWWEWWWEW" +
                                       "EEEWEEEEEEEWEEEWEW" +
                                       "EWEEEWEEEEEWEEEWEW" +
                                       "EWEEEEEWWEEWWWEEEW" +
                                       "WWEWEEEWEEEWWWWWWW";

        static private string Level3 = "EEEEWWWEEEEEEEEEEW" +
                                       "EEEEEEBEWEEEEEEEEW" +
                                       "EEWEEEBEWEEEEEEEEW" +
                                       "EEWEWWEWWEEEEEEEWW" +
                                       "EEWEEWBWEEEEEEEEEW" +
                                       "EEEEEEHHHEEEEWPEEW" +
                                       "EEEWWEWWWWWWEWWWWE" +
                                       "WWEEEEHHHHEEEEEEWE" +
                                       "WEEWEEEEEEEEEWEEWE" +
                                       "WEEWWWWEWEWWEWEEWE" +
                                       "WEEWEEWEWEWEEWEEWE" +
                                       "WEEWEBEEBBBEEWEEWE" +
                                       "WEEWEWEEWEWEEWEEEE" +
                                       "WEEEEEEEWEEEEWEEEE" +
                                       "WWWWWWWWWWWWWWWWWW";

        static private string Level6 = "WWWWWWWWWWWWWWWWWW" +
                                       "WHHHHHEEEEEEEEEEWW" +
                                       "WHHHHHEEBEBEEEEEWW" +
                                       "WHHHHHEEWEWWWWEEWW" +
                                       "WWWWWWEEWEEBEEWWWW" +
                                       "EWWWWWEEEEEEEEWWWW" +
                                       "EWEEEEEEWEEEEWWWWW" +
                                       "EWEWWWWWWEEEEWWWWW" +
                                       "EWEWEEBEEBBBEWWWWW" +
                                       "EWEWEWWEEWEBEWWWWW" +
                                       "EWEWEWEEBEEBBWWWWW" +
                                       "EWEEEBEEEEEBPWWWWW" +
                                       "EEEEEEEEEEEBBWWWWW" +
                                       "EEEEEEEEEEEEEWWWWW" +
                                       "WWWWWWWWWWEEEWWWWW";

        static private string Level2 = "EEEEEEEEEEEEEEEEEE" +
                                       "EEWWWWWWWWWWWWWWWE" +
                                       "EEWWWWEEEEEWWWWWWE" +
                                       "EEWWWWEBBBEWWWWWWE" +
                                       "EEWWWEEEEBEWEEEEWE" +
                                       "EEWWEBEEEBEWEEEEWE" +
                                       "EEWEBPBEWEEWEEEEWE" +
                                       "EEWEHBHEWEEWEEEEWE" +
                                       "EEWEHHHEWWWWEEEEWE" +
                                       "EEWEHEHEEWEEEEEEWE" +
                                       "EEWEHEHEEWWWWWWWWE" +
                                       "EEWWWWWWWWEEEEEEEE" +
                                       "EEEEEEEEEEEEEEEEEE" +
                                       "EEEEEEEEEEEEEEEEEE" +
                                       "EEEEEEEEEEEEEEEEEE";

        static public string GetLevel(int level)
        {
            switch (level)
            {
                case 1:
                    return Level1;
                case 2:
                    return Level2;
                case 3:
                    return Level3;
                case 4:
                    return Level4;
                case 5:
                    return Level5;
                case 6:
                    return Level6;
                default:
                    return Level1;
            }
        }

        static public Point FindPlayerPosition(string level)
        {
            var k = 0;
            for (var y = 0; y < rowsTilesNumber; y++)
            {
                for (var x = 0; x < columnsTilesNumber; x++)
                {
                    if (level[k] == 'P')
                    {
                        return new Point(x, y);
                    }
                    k++;
                }
            }
            return new Point();
        }

        static public List<Point> FindBoxesPositions(string level)
        {
            var result = new List<Point>();

            var k = 0;
            for (var y = 0; y < rowsTilesNumber; y++)
            {
                for (var x = 0; x < columnsTilesNumber; x++)
                {
                    if (level[k] == 'B')
                    {
                        result.Add(new Point(x, y));
                    }
                    k++;
                }
            }
            return result;
        }

        static public int GetHolesNumber(string level)
        {
            var result = 0;
            foreach(char c in level)
            {
                if (c == 'H')
                    result++;
            }
            return result;
        }
    }

}
