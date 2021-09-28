using System;
using System.Runtime.InteropServices;

namespace heroes
{
    class Program
    {
        public const string cpp = @".\engine.dll";

        [DllImport(cpp, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CSEngineInit();

        [DllImport(cpp, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CSEngineQuit();

        [DllImport(cpp, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CSEventCheck();

        static void Main(string[] args)
        {
            CSEngineInit();

            while (CSEventCheck())
            {

            }

            CSEngineQuit();
        }
    }
}
