using PraktilineTööMadu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PraktilineTööMadu
{
    class Walls
    {
        List<Figure> wallList;

        public Walls(int mapWidth, int mapHeight)
        {
            wallList = new List<Figure>();

            // Правильные координаты для стен
            HorizontalLine upLine = new HorizontalLine(0, mapWidth - 2, 0, '#');
            HorizontalLine downLine = new HorizontalLine(0, mapWidth - 2, mapHeight - 1, '#');
            VerticalLine leftLine = new VerticalLine(0, mapHeight - 1, 0, '#');
            VerticalLine rightLine = new VerticalLine(0, mapHeight - 1, mapWidth - 2, '#');

            wallList.Add(leftLine);
            wallList.Add(rightLine);
            wallList.Add(upLine);
            wallList.Add(downLine);
        }

        internal bool IsHit(Figure figure)
        {
            foreach (var wall in wallList)
            {
                if (wall.IsHit(figure))
                {
                    return true;
                }
            }
            return false;
        }

        public void Draw()
        {
            foreach (var wall in wallList)
            {
                wall.Draw();
            }
        }
    }


    //using PraktilineTööMadu;
    //using System;
    //using System.Collections.Generic;
    //using System.Linq;
    //using System.Text;
    //using System.Threading.Tasks;

    //namespace Madu_Uus
    //{
    //    internal class Walls
    //    {
    //        List<Figure> wallList;

    //        public Walls(int mapWidth, int mapHeight)
    //        {
    //            wallList = new List<Figure>();
    //            // рамочка
    //            HorizontalLine upLine = new HorizontalLine(0, mapHeight - 1, 0, '#');
    //            HorizontalLine downLine = new HorizontalLine(0, mapHeight - 1, mapWidth - 2, '#');
    //            VerticalLine leftLine = new VerticalLine(0, mapWidth - 2, 0, '#');
    //            VerticalLine rightLine = new VerticalLine(0, mapWidth - 2, mapHeight - 1, '#');

    //            wallList.Add(leftLine);
    //            wallList.Add(rightLine);
    //            wallList.Add(upLine);
    //            wallList.Add(downLine);
    //        }

    //        internal bool IsHit(Figure figure)
    //        {
    //            foreach (var wall in wallList)
    //            {
    //                if (wall.IsHit(figure))
    //                {
    //                    return true;
    //                }
    //            }
    //            return false;
    //        }

    //        public void Draw()
    //        {
    //            foreach (var wall in wallList)
    //            {
    //                wall.Draw();
    //            }
    //        }
    //    }
    //}
}