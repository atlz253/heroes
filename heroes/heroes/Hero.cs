using engn;

namespace heroes
{
    public class Hero : Entity
    {
        // private Army army;

        public Hero(int x = 0, int y = 0) : base(new Rect(Global.cellSize, Global.cellSize, x, y), Global.texture, new Rect(Global.cellSize, Global.cellSize, 928)) 
        { 

        }
    }
}