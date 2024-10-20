﻿namespace PraktilineTööMadu
{
    internal class Point
    {
        public int x;
        public int y;
        public char sym;

        public Point() { }

        public Point(int _x, int _y, char _sym)
        {
            x = _x;
            y = _y;
            sym = _sym;
        }

        public Point(Point p)
        {
            x = p.x;
            y = p.y;
            sym = p.sym;
        }

        public void Move(int offset, Direction direction)
        {
            if (direction == Direction.RIGHT)
            {
                x = x + offset;
            }
            else if (direction == Direction.LEFT)
            {
                x = x - offset;
            }
            else if (direction == Direction.UP)
            {
                y = y - offset;
            }
            else if (direction == Direction.DOWN)
            {
                y = y + offset;
            }
        }

        public bool IsHit(Point p)
        {
            return p.x == this.x && p.y == this.y;
        }

        public void Draw(int x, int y, char sym)
        {
            System.Console.SetCursorPosition(x, y);
            System.Console.Write(sym);
        }

        public void Clear()
        {
            sym = ' ';
            Draw(x, y, sym);
        }

        public override string ToString()
        {
            return x + ", " + y + ", " + sym;
        }
    }
}

//Console.SetCursorPosition(x, y);
//Console.Write(sym);

//Console.WriteLine("Luuakse uus punkt");