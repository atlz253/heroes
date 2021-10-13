using engn;

namespace heroes
{
    public class Player
    {
        private Hero heroes;

        public Hero Heroes
        {
            get
            {
                return heroes;
            }
        }
        public bool Turn { get; set; }

        public Player(Hero hero) // TODO: string name
        {
            heroes = hero;
            Turn = true;
        }
    }
}