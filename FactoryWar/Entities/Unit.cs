namespace FactoryWar.Entities;

public abstract class Unit
{
    public int MaxHealth { get; set; }
    public int Health { get; set; }
    public int TacticalAbility { get; set; }
    public int UltimateAbility { get; set; }

    protected Unit(int health, int tacticalAbility, int ultimateAbility)
    {
        Health = health;
        MaxHealth = health;
        TacticalAbility = tacticalAbility;
        UltimateAbility = ultimateAbility;
    }
    
    public abstract void MakeAMove(List<Unit> enemyUnits, List<Unit> friendlyUnits);

    protected bool ProbabilityBy(int value) => new Random().Next(1, 101) <= value;

    public virtual void TakeAttack(int valueDamage)
    {
        Health -= valueDamage;
    }
}