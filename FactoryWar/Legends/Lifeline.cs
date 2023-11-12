using FactoryWar.Entities;

namespace FactoryWar.Legends;

public class Lifeline: Support
{
    public Lifeline(int health, int tacticalAbility, int ultimateAbility, int presenceOfWeapons, int damage, int treatment, int initiative, bool haveBlocking) 
        : base(health, tacticalAbility, ultimateAbility, presenceOfWeapons, damage, treatment, initiative, haveBlocking)
    {
    }

    public override void MakeAMove(List<Unit> enemyUnits, List<Unit> friendlyUnits)
    {
        Console.WriteLine($"{nameof(Lifeline)} делает ход...");
        if (ProbabilityBy(TacticalAbility)) Heal(friendlyUnits[new Random().Next(0,friendlyUnits.Count - 1)]);
        else if (ProbabilityBy(UltimateAbility)) GroupHeal(friendlyUnits);
        else Attack(enemyUnits[new Random().Next(0,enemyUnits.Count - 1)]);
    }

    public override void Attack(Unit unit)
    {
        if (ProbabilityBy(PresenceOfWeapons))
        {
            Console.WriteLine($"{nameof(Lifeline)} атакует.");
            unit.TakeDamage(Damage);
        }
        else
        {
            Console.WriteLine($"{nameof(Lifeline)} промахивается.");
        }
    }
    
    public override void TakeDamage(int valueDamage)
    {
        if (HaveBlocking)
        {
            Console.WriteLine($"У {nameof(Lifeline)} был блок, урон не получен.");
            HaveBlocking = false;
        }
        else
        {
            base.TakeDamage(valueDamage);
            Console.WriteLine(Health > 0
                ? $"{nameof(Lifeline)} получила урон, оставшееся здоровье: {Health}/{MaxHealth}"
                : $"{nameof(Lifeline)} получила урон и умерла");
        }
    }


    public override void Heal(Unit unit)
    {
        string message;
        var valueIncrease = unit.MaxHealth - unit.Health;
        if (valueIncrease >= Treatment)
        {
            unit.Health += Treatment;
            message = $"{nameof(Lifeline)} вылечила {unit.GetType().Name} на {Treatment}";
        }
        else
        {
            unit.Health += valueIncrease;
            message = $"{nameof(Lifeline)} вылечила {unit.GetType().Name} на {valueIncrease}";
        }
        Console.WriteLine(message);
    }

    public override void GroupHeal(List<Unit> units)
    {
        Console.WriteLine($"{nameof(Lifeline)} захиллила всю команду.");
        units.ForEach(Heal);
    }
}