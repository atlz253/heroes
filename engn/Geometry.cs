using System;
using System.Runtime.InteropServices;

namespace engn
{
    public class Line
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
}