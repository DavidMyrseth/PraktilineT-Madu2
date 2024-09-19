using PraktilineTööMadu;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PraktilineTööMadu
{
    internal class HorizontalLine : Figure
    {
        public HorizontalLine(int xLeft, int xReight, int y, char sym)
        {
            pList = new List<Point>();
            for (int x = xLeft; x <= xReight; x++)
            {
                Point p = new Point(x, y, sym);
                pList.Add(p);
            }
        }
        public override void Draw()
        {
            base.Draw();
        }
    }
}

// 13 
//foreach (Point p in pList)
//{
//    p.Draw();
//}

//Console.ForegroundColor = ConsoleColor.White;

// Кусочек из восьмого урока убран так как данная информация даеться из Figure
//List<Point> pList;

//public void Drow()
//{
//    foreach (Point p in pList)
//    {
//        p.Draw();
//    }
//}

//Point p1 = new Point(4, 4, '*'); Конструктор
//Point p2 = new Point(5, 5, '*');
//Point p3 = new Point(6, 4, '*');
//pList.Add(p1);
//pList.Add(p2);
//pList.Add(p3);