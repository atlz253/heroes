using System.Runtime.InteropServices;

namespace engn
{
    public static class Mouse
    {
        [DllImport(@"./engine")] private static extern Point MousePosition();
        public static Point Position
        {
            get
            {
                return MousePosition();
            }
        }

        [DllImport(@"./engine")] private static extern bool MouseLeftClick();
        public static bool LeftClick
        {
            get
            {
                return MouseLeftClick();
            }
        }
    }
}