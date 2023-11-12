using FactoryWar.Entities;

namespace FactoryWar.Legends;

public class Loba: Support
{
    public Loba(int health, int tacticalAbility, int ultimateAbility, int presenceOfWeapons, int damage, int treatment, int initiative, bool haveBlocking) 
        : base(health, tacticalAbility, ultimateAbility, presenceOfWeapons, damage, treatment, initiative, haveBlocking)
    {
    }

    public override void MakeAMove(List<Unit> enemyUnits, List<Unit> friendlyUnits)
    {
        Console.WriteLine($"{nameof(Loba)} делает ход...");
        if (ProbabilityBy(UltimateAbility)) GroupHeal(friendlyUnits);
        else Attack(enemyUnits[new Random().Next(0,enemyUnits.Count - 1)]);
    }
    public override void Attack(Unit unit)
    {
        if (ProbabilityBy(PresenceOfWeapons))
        {
            Console.WriteLine($"{nameof(Loba)} атакует.");
            unit.TakeDamage(Damage);
        }
        else
        {
            Console.WriteLine($"{nameof(Loba)} промахивается.");
        }
    }
    public override void TakeDamage(int valueDamage)
    {
        if (HaveBlocking)
        {
            Console.WriteLine($"У {nameof(Loba)} был блок, урон не получен.");
            HaveBlocking = false;
        }
        else
        {
            if (ProbabilityBy(TacticalAbility))
            {
                Console.WriteLine($"{nameof(Loba)} телепортируется и не получает урон.");
            }
            else
            {
                base.TakeDamage(valueDamage);
                Console.WriteLine(Health > 0
                    ? $"{nameof(Loba)} получила урон, оставшееся здоровье: {Health}/{MaxHealth}."
                    : $"{nameof(Loba)} получила урон и умерла.");
            }
        }
    }
    public override void Heal(Unit unit)
    {
        string message;
        var valueIncrease = unit.MaxHealth - unit.Health;
        if (valueIncrease >= Treatment)
        {
            unit.Health += Treatment;
            message = $"У {unit.GetType().Name} восстановленно здоровье на {Treatment}";
        }
        else
        {
            unit.Health += valueIncrease;
            message = $"У {unit.GetType().Name} восстановленно здоровье на  {valueIncrease}";
        }
        Console.WriteLine(message);
    }
    public override void GroupHeal(List<Unit> units)
    {
        Console.WriteLine($"{nameof(Loba)} поставила чёрный рынок и вся команда смогла полечиться: ");
        units.ForEach(Heal);
    }
}