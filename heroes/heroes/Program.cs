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
        public static Player[] players = { new Player(new Hero()), new Player(new Hero()) };
    }

    interface IScene
    {
        void Process();
        void Render();
    }

    public sealed class World : IScene
    {
        private static List<Line> vertical = new List<Line>(), horizontal = new List<Line>();
        private static Entity[,] background = new Entity[Global.screenSize / Global.cellSize, Global.screenSize / Global.cellSize],
                                 action = new Entity[Global.screenSize / Global.cellSize, Global.screenSize / Global.cellSize];
        private static Rectangle[,] highlight = new Rectangle[Global.screenSize / Global.cellSize, Global.screenSize / Global.cellSize];

        public World()
        {
            InitGrid();
            InitBackground();

            action[5, 5] = Global.players[0].Heroes;
            Global.players[0].Heroes.SetPosition(5 * Global.cellSize, 5 * Global.cellSize);
            Global.players[1].Heroes.SetPosition(10 * Global.cellSize, 10 * Global.cellSize);
            action[10, 10] = Global.players[1].Heroes;
            Global.players[0].Turn = true;
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

        public void DrawHighlight(int x, int y)
        {
            highlight = new Rectangle[Global.screenSize / Global.cellSize, Global.screenSize / Global.cellSize];

            highlight[x, y] = new Rectangle((Global.cellSize, Global.cellSize, x * Global.cellSize, y * Global.cellSize), (0, 0, 255, 120));
            x--;
            if (x >= 0)
                highlight[x, y] = new Rectangle((Global.cellSize, Global.cellSize, x * Global.cellSize, y * Global.cellSize), (0, 0, 255, 120));
            y++;
            if (y >= 0)
                highlight[x, y] = new Rectangle((Global.cellSize, Global.cellSize, x * Global.cellSize, y * Global.cellSize), (0, 0, 255, 120));
            for (int i = 0; i < 2; i++)
            {
                x++;
                if (x <= Global.screenSize)
                    highlight[x, y] = new Rectangle((Global.cellSize, Global.cellSize, x * Global.cellSize, y * Global.cellSize), (0, 0, 255, 120));
            }
            for (int i = 0; i < 2; i++)
            {
                y--;
                if (y <= Global.screenSize)
                    highlight[x, y] = new Rectangle((Global.cellSize, Global.cellSize, x * Global.cellSize, y * Global.cellSize), (0, 0, 255, 120));
            }
            for (int i = 0; i < 2; i++)
            {
                x--;
                if (x >= 0)
                    highlight[x, y] = new Rectangle((Global.cellSize, Global.cellSize, x * Global.cellSize, y * Global.cellSize), (0, 0, 255, 120));
            }
        }

        public void Process()
        {
            Player player = Global.players[0].Turn ? Global.players[0] : Global.players[1];
            
            DrawHighlight(player.Heroes.X / Global.cellSize, player.Heroes.Y / Global.cellSize);
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

        private void RenderHighlight()
        {
            for (int i = 0; i < Global.screenSize / Global.cellSize; i++)
                for (int j = 0; j < Global.screenSize / Global.cellSize; j++)
                    if (highlight[i, j] != null)
                        highlight[i, j].RenderFill();
        }

        public void Render()
        {
            RenderBackground();
            RenderHighlight();
            RenderGrid();

            Global.players[0].Heroes.Render();
            Global.players[1].Heroes.Render();
        }
    }

    static class Program
    {
        static void Main(string[] args)
        {
            Engine.Init(Global.screenSize, Global.screenSize);

            IScene world = new World();

            while (Event.Check())
            {
                Render.Clear();

                world.Process();
                world.Render();

                Render.Present();
            }

            Engine.Quit();
        }
    }
}
