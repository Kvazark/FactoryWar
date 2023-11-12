namespace FactoryWar.Entities;

public abstract class Support:Unit
{
    public int Treatment { get; set; }

    protected Support(int health, int tacticalAbility, int ultimateAbility, int presenceOfWeapons, int damage, int treatment, int initiative, bool haveBlocking) 
        : base(health, tacticalAbility,ultimateAbility, presenceOfWeapons, damage, initiative, haveBlocking)
    {
        Treatment = treatment;
    }

    public abstract void Heal(Unit unit);
    public abstract void GroupHeal(List<Unit> units);
}
