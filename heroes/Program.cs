using engn;
using System;
using System.Collections.Generic;

namespace heroes
{
    static class Program
    {
        private const int screenSize = 960, cellSize = 32;
        private static Random rnd = new Random();
        private static List<Line> vertical = new List<Line>(), horizontal = new List<Line>();
        private static Entity[,] background = new Entity[screenSize/cellSize, screenSize/cellSize];

        private static void InitGrid()
        {
            for (int i = 1; i < screenSize / cellSize; i++)
            {
                vertical.Add(new Line((cellSize * i, 0), (cellSize * i, screenSize), (255, 255, 255, 120)));
                horizontal.Add(new Line((0, cellSize * i), (screenSize, cellSize * i), (255, 255, 255, 120)));
            }
        }

        private static void InitBackground()
        {
            for (int i = 0; i < screenSize / cellSize; i++)
                for (int j = 0; j < screenSize / cellSize; j++)
                    background[i, j] = new Entity((cellSize, cellSize, (short) (i * cellSize), (short) (j * cellSize)), "/home/fedor/Desktop/heroes/heroes/heroes/res/textures.png", (cellSize, cellSize, (short)(cellSize * rnd.Next(2)), (short)(cellSize * rnd.Next(2))));
        }

        private static void RenderGrid()
        {
            foreach (Line line in vertical)
                    line.Render();
            foreach (Line line in horizontal)
                    line.Render();
        }

        private static void RenderBackground()
        {
            for (int i = 0; i < screenSize / cellSize; i++)
                for (int j = 0; j < screenSize / cellSize; j++)
                    background[i, j].Render();
        }

        static void Main(string[] args)
        {
            Engine.Init(screenSize, screenSize);

            InitGrid();
            InitBackground();

            while (Event.Check())
            {
                Render.Clear();
                
                RenderBackground();
                RenderGrid();

                Render.Present();
            }

            Engine.Quit();
        }
    }
}
