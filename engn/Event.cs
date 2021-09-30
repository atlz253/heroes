using System.Runtime.InteropServices;

namespace engn
{
    public static class Event
    {
        [DllImport(@"./engine", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool EventCheck();

        public static bool Check()
        {
            return EventCheck();
        }
    }
}