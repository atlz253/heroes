namespace engn
{
    public struct Rect
    {
        public short x, y;
        public ushort w, h;

        public Rect(ushort w, ushort h, short x = 0, short y = 0)
        {
            this.w = w;
            this.h = h;
            this.x = x;
            this.y = y;
        }
    }

    public struct Point
    {
        public int x;
        public int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public struct Color
    {
        public char r;
        public char g;
        public char b;
        public char a;

        public Color(char r, char g, char b, char a)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }
    }
}