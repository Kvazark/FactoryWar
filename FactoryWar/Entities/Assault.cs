namespace FactoryWar.Entities;

public abstract class Assault : Unit
{
    public int Damage { get; set; }
    public int Dexterity { get; set; }

    protected Assault(int health, int tacticalAbility, int ultimateAbility, int damage, int dexterity) 
        : base(health, tacticalAbility,ultimateAbility)
    {
        Damage = damage;
        Dexterity = dexterity;
    }

    public abstract void Attack(Unit unit);
}