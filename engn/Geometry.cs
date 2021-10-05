using System;
using System.Runtime.InteropServices;

namespace engn
{
    public sealed class Line
    {
        private readonly IntPtr _line;

        [DllImport(@"./engine")] private static extern IntPtr CreateLine(Point start, Point end);
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

        [DllImport(@"./engine")] private static extern void SetStartLine(IntPtr line, Point start);
        public void SetStart(Point start)
        {
            SetStartLine(_line, start);
        }

        [DllImport(@"./engine")] private static extern void SetEndLine(IntPtr line, Point end);
        public void SetEnd(Point end)
        {
            SetEndLine(_line, end);
        }

        [DllImport(@"./engine")] private static extern void SetColorLine(IntPtr line, Color color);
        public void SetColor(Color color)
        {
            SetColorLine(_line, color);
        }

        [DllImport(@"./engine")] private static extern void RenderLine(IntPtr line);
        public void Render()
        {
            RenderLine(_line);
        }

        [DllImport(@"./engine")] private static extern void DeleteLine(IntPtr line);
        ~Line()
        {
            DeleteLine(_line);
        }
    }

    public sealed class Rectangle
    {
        IntPtr _rect;

        [DllImport(@"./engine")] private static extern ushort GetWRectangle(IntPtr rectangle);
        [DllImport(@"./engine")] private static extern void SetWRectangle(IntPtr rectangle, ushort w);
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

        [DllImport(@"./engine")] private static extern ushort GetHRectangle(IntPtr rectangle);
        [DllImport(@"./engine")] private static extern void SetHRectangle(IntPtr rectangle, ushort h);
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

        [DllImport(@"./engine")] private static extern short GetXRectangle(IntPtr rectangle);
        [DllImport(@"./engine")] private static extern void SetXRectangle(IntPtr rectangle, short x);
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

        [DllImport(@"./engine")] private static extern short GetYRectangle(IntPtr rectangle);
        [DllImport(@"./engine")] private static extern void SetYRectangle(IntPtr rectangle, short y);
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

        [DllImport(@"./engine")] private static extern IntPtr CreateRectangle(Rect rect);
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

        [DllImport(@"./engine")] private static extern void SetColorRectangle(IntPtr rectangle, Color color);
        public void SetColor(Color color)
        {
            SetColorRectangle(_rect, color);
        }

        [DllImport(@"./engine")] private static extern void RenderRectangle(IntPtr rectangle);
        public void Render()
        {
            RenderRectangle(_rect);
        }

        [DllImport(@"./engine")] private static extern void RenderFillRectangle(IntPtr rectangle);
        public void RenderFill()
        {
            RenderFillRectangle(_rect);
        }

        [DllImport(@"./engine")] private static extern void DeleteRectangle(IntPtr rectangle);
        ~Rectangle()
        {
            DeleteRectangle(_rect);
        }
    }
}