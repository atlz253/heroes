using engn;
using System;
using System.Collections.Generic;

namespace heroes
{
    public static class Global
    {
        public static Random rnd = new Random();
        public const int screenSize = 800, cellSize = 32;
        public const string texture = "./textures.png";
    }

    public sealed class World
    {
        private static List<Line> vertical = new List<Line>(), horizontal = new List<Line>();
        private static Entity[,] background = new Entity[Global.screenSize / Global.cellSize, Global.screenSize / Global.cellSize];

        public World()
        {
            InitGrid();
            InitBackground();
        }

        private void InitGrid()
        {
            for (int i = 1; i < Global.screenSize / Global.cellSize; i++)
            {
                vertical.Add(new Line((Global.cellSize * i, 0), (Global.cellSize * i, Global.screenSize), (255, 255, 255, 120)));
                horizontal.Add(new Line((0, Global.cellSize * i), (Global.screenSize, Global.cellSize * i), (255, 255, 255, 120)));
            }
        }

        private void InitBackground()
        {
            for (int i = 0; i < Global.screenSize / Global.cellSize; i++)
                for (int j = 0; j < Global.screenSize / Global.cellSize; j++)
                    background[i, j] = new Entity((Global.cellSize, Global.cellSize, (short)(i * Global.cellSize), (short)(j * Global.cellSize)), Global.texture, (Global.cellSize, Global.cellSize, (short)(Global.cellSize * Global.rnd.Next(2)), (short)(Global.cellSize * Global.rnd.Next(2))));
        }

        public void Render()
        {
            RenderBackground();
            RenderGrid();
        }

        private void RenderGrid()
        {
            foreach (Line line in vertical)
                line.Render();
            foreach (Line line in horizontal)
                line.Render();
        }

        private void RenderBackground()
        {
            for (int i = 0; i < Global.screenSize / Global.cellSize; i++)
                for (int j = 0; j < Global.screenSize / Global.cellSize; j++)
                    background[i, j].Render();
        }
    }

    static class Program
    {
        static void Main(string[] args)
        {
            Engine.Init(Global.screenSize, Global.screenSize);

            World world = new World();

            while (Event.Check())
            {
                Render.Clear();

                world.Render();

                Render.Present();
            }

            Engine.Quit();
        }
    }
}
