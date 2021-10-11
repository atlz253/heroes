using engn;
using System;

namespace heroes
{
    public class Army : Entity
    {
        public Army(short x = 0, short y = 0) : base(new Rect(Global.cellSize, Global.cellSize, x, y), "/home/fedor/Desktop/heroes/heroes/heroes/res/textures.png", new Rect(Global.cellSize, Global.cellSize, 928)) { }

        public override void Process()
        {
            
        }
    }
}