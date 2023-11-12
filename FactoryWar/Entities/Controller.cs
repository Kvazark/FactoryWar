namespace FactoryWar.Entities;

public abstract class Controller: Unit
{
    public int Blocking { get; set; }

    protected Controller(int health, int tacticalAbility, int ultimateAbility, int presenceOfWeapons, int damage, int blocking, int initiative, bool haveBlocking) 
        : base(health, tacticalAbility,ultimateAbility, presenceOfWeapons, damage, initiative, haveBlocking)
    {
        Blocking = blocking;
    }

    public abstract void PutABlock(Unit unit);
}
