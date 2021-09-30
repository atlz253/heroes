using System;
using System.Runtime.InteropServices;

namespace engn
{
    public static class Engine
    {
        [DllImport(@"./engine")]
        private static extern bool CSEngineInit();

        [DllImport(@"./engine")]
        private static extern bool CSEngineQuit();

        public static bool Init()
        {
            return CSEngineInit();
        }

        public static bool Quit()
        {
            return CSEngineQuit();
        }
    }

    public static class Render
    {
        [DllImport(@"./engine")]
        private static extern bool CSRenderClear();

        [DllImport(@"./engine")]
        private static extern void CSRenderPresent();

        public static bool Clear()
        {
            return CSRenderClear();
        }

        public static void Present()
        {
            CSRenderPresent();
        }
    }
}
