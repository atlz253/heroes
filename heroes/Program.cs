using engn;
using System;

namespace heroes
{
    class Program
    {
        static void Main(string[] args)
        {
            Engine.Init();

            while (Event.Check())
            {
                
            }

            Engine.Quit();
        }
    }
}
