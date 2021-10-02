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

        public Color(int r, int g, int b, int a) // FIXME: values check
        {
            this.r = (char)r;
            this.g = (char)g;
            this.b = (char)b;
            this.a = (char)a;
        }

        public Color((char, char, char, char) color)
        {
            this.r = color.Item1;
            this.g = color.Item2;
            this.b = color.Item3;
            this.a = color.Item4;
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