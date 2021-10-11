using engn;

namespace heroes
{
    public class Hero : Entity
    {
        // private Army army;
        private Player player;

        public Player Player
        {
            get
            {
                return player;
            }
        }

        public Hero(Player player, short x = 0, short y = 0) : base(new Rect(Global.cellSize, Global.cellSize, x, y), "/home/fedor/Desktop/heroes/heroes/heroes/res/textures.png", new Rect(Global.cellSize, Global.cellSize, 928)) 
        { 
            this.player = player;
        }
    }
}