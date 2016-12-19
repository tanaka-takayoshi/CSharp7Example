namespace CSharp7Example
{

    class Point
    {
        public int X { get; }
        public int Y { get; }

        public Point(int x, int y) { X = x; Y = y; }
        public void Deconstruct(out int x, out int y)
        {
            x = X;
            y = Y;
        }
        public void GetCoordinates(out int x, out int y)
        {
            x = X;
            y = Y;
        }
    }
}
