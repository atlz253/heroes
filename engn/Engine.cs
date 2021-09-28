using System;

namespace engn
{
    public class Engine
    {
        private const string cpp = @"./engine.lib";

        [DllImport(cpp, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CSEngineInit();

        [DllImport(cpp, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CSEngineQuit();

        [DllImport(cpp, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CSEventCheck();

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
