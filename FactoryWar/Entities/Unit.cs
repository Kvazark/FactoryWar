namespace FactoryWar.Entities;

public abstract class Unit
{
    public int MaxHealth { get; set; }
    public int Health { get; set; }
    public int TacticalAbility { get; set; }
    public int UltimateAbility { get; set; }
    public int PresenceOfWeapons { get; set; }
    public int Damage { get; set; }
    public int Initiative { get; set; }
    public bool HaveBlocking { get; set; }

    protected Unit(int health, int tacticalAbility, int ultimateAbility, int presenceOfWeapons, int damage, int initiative, bool haveBlocking)
    {
        Health = health;
        MaxHealth = health;
        TacticalAbility = tacticalAbility;
        UltimateAbility = ultimateAbility;
        PresenceOfWeapons = presenceOfWeapons;
        Damage = damage;
        Initiative = initiative;
        HaveBlocking = haveBlocking;

    }
    
    public abstract void MakeAMove(List<Unit> enemyUnits, List<Unit> friendlyUnits);
    public abstract void Attack(Unit unit);

    protected bool ProbabilityBy(int value) => new Random().Next(1, 11) <= value;

    public virtual void TakeDamage(int valueDamage)
    {
        Health -= valueDamage;
    }
}