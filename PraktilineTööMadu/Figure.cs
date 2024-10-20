﻿namespace PraktilineTööMadu
{
    internal class Figure
    {
        protected List<Point> pList;
        public virtual void Draw()
        {
            foreach (Point p in pList)
            {
                p.Draw(p.x, p.y, p.sym);
            }
        }
        internal bool IsHit(Figure figure)
        {
            foreach (var p in pList)
            {
                if (figure.IsHit(p))
                    return true;
            }
            return false;
        }
        private bool IsHit(Point point)
        {
            foreach (var p in pList)
            {
                if (p.IsHit(point))
                    return true;
            }
            return false;
        }
    }
}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace PraktilineTööMadu
//{
//    class Figure
//    {
//        protected List<Point> pList;

//        public virtual void Draw()
//        {
//            foreach ( Point p in pList )
//            {
//                p.Draw();
//            }
//        }

//        internal bool IsHit(Figure figure) 
//        {
//            foreach (var p in pList) 
//            foreach (var p in pList) 
//            { 
//                if (p.IsHit( p ))
//                    return true;
//            }
//            return false;
//        }

//        private bool IsHit(Point point)
//        {
//            foreach (var p in pList)
//            { 
//                if (p.IsHit( point )) 
//                    return true;
//            }
//            return false;
//        }
//    }
//}