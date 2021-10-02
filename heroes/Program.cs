using engn;
using System;
using System.Collections.Generic;

namespace heroes
{
    class Program
    {
        private const int screenSize = 960, cellSize = 32;

        private static List<Line> vertical = new List<Line>(), horizontal = new List<Line>();

        private static void InitGrid()
        {
            for (int i = 1; i < screenSize / cellSize; i++)
            {
                vertical.Add(new Line((cellSize * i, 0), (cellSize * i, screenSize), (255, 255, 255, 127)));
                horizontal.Add(new Line((0, cellSize * i), (screenSize, cellSize * i), (255, 255, 255, 127)));
            }
        }

        private static void RenderGrid()
        {
            foreach (Line line in vertical)
                    line.Render();
            foreach (Line line in horizontal)
                    line.Render();
        }

        static void Main(string[] args)
        {
            Engine.Init(screenSize, screenSize);

            InitGrid();

            while (Event.Check())
            {
                Render.Clear();

                RenderGrid();

                Render.Present();
            }

            Engine.Quit();
        }
    }
}
