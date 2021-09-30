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
}