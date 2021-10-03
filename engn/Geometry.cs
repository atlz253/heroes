using System;
using System.Runtime.InteropServices;

namespace engn
{
    public sealed class Line
    {
        private readonly IntPtr _line;

        [DllImport(@"./engine")] private static extern IntPtr CreateLine(Point start, Point end);
        [DllImport(@"./engine")] private static extern void SetStartLine(IntPtr line, Point start);
        [DllImport(@"./engine")] private static extern void SetEndLine(IntPtr line, Point end);
        [DllImport(@"./engine")] private static extern void SetColorLine(IntPtr line, Color color);
        [DllImport(@"./engine")] private static extern void RenderLine(IntPtr line);
        [DllImport(@"./engine")] private static extern void DeleteLine(IntPtr line);

        public Line(Point start, Point end)
        {
            _line = CreateLine(start, end);
        }

        public Line((int, int) start, (int, int) end)
        {
            _line = CreateLine(new Point(start.Item1, start.Item2), new Point(end.Item1, end.Item2));
        }

        public Line(Point start, Point end, Color color) : this(start, end)
        {
            SetColor(color);
        }

        public Line((int, int) start, (int, int) end, (char, char, char, char) color) : this(start, end)
        {
            SetColor(new Color(color.Item1, color.Item2, color.Item3, color.Item4));
        }

        public Line((int, int) start, (int, int) end, (int, int, int, int) color) : this(start, end)
        {
            SetColor(new Color(color.Item1, color.Item2, color.Item3, color.Item4));
        }

        public void SetStart(Point start)
        {
            SetStartLine(_line, start);
        }

        public void SetEnd(Point end)
        {
            SetEndLine(_line, end);
        }

        public void SetColor(Color color)
        {
            SetColorLine(_line, color);
        }

        public void Render()
        {
            RenderLine(_line);
        }

        ~Line()
        {
            DeleteLine(_line);
        }
    }

    public sealed class Rectangle
    {
        IntPtr _rect;

        [DllImport(@"./engine")] private static extern IntPtr CreateRectangle(Rect rect);
        [DllImport(@"./engine")] private static extern void SetWRectangle(IntPtr rectangle, ushort w);
        [DllImport(@"./engine")] private static extern void SetHRectangle(IntPtr rectangle, ushort h);
        [DllImport(@"./engine")] private static extern ushort GetWRectangle(IntPtr rectangle);
        [DllImport(@"./engine")] private static extern ushort GetHRectangle(IntPtr rectangle);
        [DllImport(@"./engine")] private static extern void SetXRectangle(IntPtr rectangle, short x);
        [DllImport(@"./engine")] private static extern void SetYRectangle(IntPtr rectangle, short y);
        [DllImport(@"./engine")] private static extern short GetXRectangle(IntPtr rectangle);
        [DllImport(@"./engine")] private static extern short GetYRectangle(IntPtr rectangle);
        [DllImport(@"./engine")] private static extern void SetColorRectangle(IntPtr rectangle, Color color);
        [DllImport(@"./engine")] private static extern void RenderRectangle(IntPtr rectangle);
        [DllImport(@"./engine")] private static extern void RenderFillRectangle(IntPtr rectangle);
        [DllImport(@"./engine")] private static extern void DeleteRectangle(IntPtr rectangle);

        public ushort W
        {
            get
            {
                return GetWRectangle(_rect);
            }

            set
            {
                SetWRectangle(_rect, value);
            }
        }

        public ushort H
        {
            get
            {
                return GetHRectangle(_rect);
            }

            set
            {
                SetHRectangle(_rect, value);
            }
        }

        public short X
        {
            get
            {
                return GetXRectangle(_rect);
            }

            set
            {
                SetXRectangle(_rect, value);
            }
        }

        public short Y
        {
            get
            {
                return GetYRectangle(_rect);
            }

            set
            {
                SetYRectangle(_rect, value);
            }
        }

        public Rectangle(Rect rect)
        {
            _rect = CreateRectangle(rect);
        }

        public Rectangle((ushort, ushort, short, short) rect) : this(new Rect(rect)) { }

        public Rectangle(Rect rect, Color color) : this(rect)
        {
            SetColor(color);
        }

        public Rectangle((ushort, ushort, short, short) rect, (int, int, int, int) color) : this(new Rect(rect), new Color(color)) { }

        public void SetColor(Color color)
        {
            SetColorRectangle(_rect, color);
        }

        public void Render()
        {
            RenderRectangle(_rect);
        }

        public void RenderFill()
        {
            RenderFillRectangle(_rect);
        }

        ~Rectangle()
        {
            DeleteRectangle(_rect);
        }
    }
}