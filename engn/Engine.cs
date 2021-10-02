using System;
using System.Runtime.InteropServices;

namespace engn
{
    public static class Engine
    {
        [DllImport(@"./engine")]
        private static extern bool EngineInit(int w, int h);

        [DllImport(@"./engine")]
        private static extern bool EngineQuit();

        public static bool Init(int w = 1280, int h = 720)
        {
            return EngineInit(w, h);
        }

        public static bool Quit()
        {
            return EngineQuit();
        }
    }

    public static class Render
    {
        [DllImport(@"./engine")]
        private static extern bool RenderClear();

        [DllImport(@"./engine")]
        private static extern void RenderPresent();

        public static bool Clear()
        {
            return RenderClear();
        }

        public static void Present()
        {
            RenderPresent();
        }
    }
}
