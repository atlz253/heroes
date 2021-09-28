using System;
using System.Runtime.InteropServices;

namespace engn
{
    public class Engine
    {
        [DllImport(@"./engine", CallingConvention = CallingConvention.Cdecl)]
        private static extern int CSEngineInit();

        [DllImport(@"./engine", CallingConvention = CallingConvention.Cdecl)]
        private static extern int CSEngineQuit();

        public static int Init()
        {
            return CSEngineInit();
        }

        public static int Quit()
        {
            return CSEngineQuit();
        }
    }
}
