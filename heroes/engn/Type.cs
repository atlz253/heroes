namespace engn
{
    public struct Rect
    {
        public short x, y;
        public ushort w, h;

        public Rect(int w, int h, int x = 0, int y = 0)
        {
            this.w = (ushort) w;
            this.h = (ushort) h;
            this.x = (short) x;
            this.y = (short) y;
        }
        public Rect((int, int, int, int) rect) 
        { 
            this.w = (ushort) rect.Item1;
            this.h = (ushort) rect.Item2;
            this.x = (short) rect.Item3;
            this.y = (short) rect.Item4;
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

        public Color(int r, int g, int b, int a) // FIXME: values check
        {
            this.r = (char)r;
            this.g = (char)g;
            this.b = (char)b;
            this.a = (char)a;
        }
        public Color((int, int, int, int) color) // FIXME: values check
        {
            this.r = (char)color.Item1;
            this.g = (char)color.Item2;
            this.b = (char)color.Item3;
            this.a = (char)color.Item4;
        }

        public static Color White
        {
            get
            {
                return new Color((char)255, (char)255, (char)255, (char)255);
            }
        }
    }
}