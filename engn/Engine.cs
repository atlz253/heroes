using System;
using System.Runtime.InteropServices;

namespace engn
{
    public class Engine
    {
        [DllImport(@"./engine", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool CSEngineInit();

        [DllImport(@"./engine", CallingConvention = CallingConvention.Cdecl)]
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
}
