namespace FactoryWar.Entities;

public abstract class Controller: Unit
{
    public int Damage { get; set; }
    public int Blocking { get; set; }

    protected Controller(int health, int tacticalAbility, int ultimateAbility, int damage, int blocking) 
        : base(health, tacticalAbility,ultimateAbility)
    {
        Damage = damage;
        Blocking = blocking;
    }

    public abstract void PutABlock(Unit unit);
    public abstract void Attack(Unit unit);
}
