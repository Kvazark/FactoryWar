using FactoryWar.Entities;

namespace FactoryWar.Legends;

public class Bangalore: Assault
{
    public Bangalore(int health, int tacticalAbility, int ultimateAbility, int damage, int dexterity) : base(health, tacticalAbility, ultimateAbility, damage, dexterity)
    {
    }

    public override void MakeAMove(List<Unit> enemyUnits, List<Unit> friendlyUnits)
    {
        if (ProbabilityBy(TacticalAbility))
        {
            Console.WriteLine($"{nameof(Bangalore)} атакует");
        }
        else
        {
            base.TakeAttack(10);
        }
    }
    public override void TakeAttack(int valueDamage)
    {
        base.TakeAttack(valueDamage);
        Console.WriteLine(Health > 0
            ? $"{nameof(Bangalore)} получила урон, оставшееся здоровье: {Health}/{MaxHealth}"
            : $"{nameof(Bangalore)} получила урон и умерла");
    }

    public override void Attack(Unit unit)
    {
        if (ProbabilityBy(UltimateAbility))
        {
            Console.WriteLine($"{nameof(Bangalore)} атакует");
            unit.TakeAttack(Damage);
        }
        else
        {
            Console.WriteLine($"{nameof(Bangalore)} промахивается");
        }
    }
}