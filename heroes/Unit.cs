using engn;

namespace heroes
{
    public interface IAttack
    {
        void Attack();
    }

    // public interface ISpecial
    // {
    //     void Special();
    // }

    public class Unit : Entity
    {
        protected ushort hp = 100;
        protected ushort speed = 1;
        protected ushort protection = 0;
        protected IAttack attack;
        
    }

    public class Villager : Unit
    {

    }
}