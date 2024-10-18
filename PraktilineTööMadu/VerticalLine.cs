namespace PraktilineTööMadu
{
    internal class VerticalLine : Figure
    {
        public VerticalLine(int yUp, int yDown, int x, char sym)
        {
            pList = new List<Point>();
            for (int y = yUp; y <= yDown; y++)
            {
                Point p = new Point(x, y, sym);
                pList.Add(p);
            }
        }
    }
}


//List<Point> pList;
//public void Drow()
//{
//    foreach (Point p in pList)
//    {
//        p.Draw();
//    }
//}
