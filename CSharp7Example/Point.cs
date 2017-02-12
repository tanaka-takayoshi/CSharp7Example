namespace CSharp7Example
{

    class Point
    {
        public int X { get; }
        public int Y { get; private set; }

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

        public void GetXSetY(out int x, int y)
        {
            x = X;
            Y = y;
        }

        public void GetX(out int x)
        {
            x = X;
        }
        public void GetX(out long x)
        {
            x = X;
        }
        
    }
}
