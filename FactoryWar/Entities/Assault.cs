namespace FactoryWar.Entities;

public abstract class Assault : Unit
{
    public int UltimateDamage { get; set; }

    protected Assault(int health, int tacticalAbility, int ultimateAbility, int presenceOfWeapons, int damage, int ultimateDamage, int initiative, bool haveBlocking) 
        : base(health, tacticalAbility,ultimateAbility,presenceOfWeapons, damage, initiative, haveBlocking)
    {
        UltimateDamage = ultimateDamage;
    }

    public abstract void AdditionalAttack(Unit unit);
    
}