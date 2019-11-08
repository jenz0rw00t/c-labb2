using System;

namespace Labb1
{
    public class Position
    {
        private int _x;
        private int _y;

        public int X
        {
            get => _x;
            set => _x = Math.Abs(value);
        }
        public int Y
        {
            get => _y;
            set => _y = Math.Abs(value);
        }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }


        public double Length() => Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));

        public bool Equals(Position p) => p.X == X && p.Y == Y;

        public Position Clone() => new Position(X, Y);

        public override string ToString() => $"({X},{Y})";

        public static bool operator >(Position p1, Position p2)
        {
            if (p1.Length() == p2.Length())
            {
                return p1.X > p2.X;
            }
            return p1.Length() > p2.Length();
        }

        public static bool operator <(Position p1, Position p2)
        {
            if (p1.Length() == p2.Length())
            {
                return p1.X < p2.X;
            }
            return p1.Length() < p2.Length();
        }

        public static Position operator +(Position p1, Position p2) => new Position(p1.X + p2.X, p1.Y + p2.Y);

        public static Position operator -(Position p1, Position p2) => new Position(p1.X - p2.X, p1.Y - p2.Y);

        public static double operator %(Position p1, Position p2) => Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
    }
}