namespace FactoryWar.Entities;

public abstract class Support:Unit
{
    public int Treatment { get; set; }
    public int Dexterity { get; set; }

    protected Support(int health, int tacticalAbility, int ultimateAbility, int treatment, int dexterity) 
        : base(health, tacticalAbility,ultimateAbility)
    {
        Treatment = treatment;
        Dexterity = dexterity;
    }

    public abstract void Heal(Unit unit);
    public abstract void GroupHeal(List<Unit> units);
}
