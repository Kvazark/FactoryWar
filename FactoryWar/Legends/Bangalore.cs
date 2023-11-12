using FactoryWar.Entities;

namespace FactoryWar.Legends;

public class Bangalore: Assault
{
    public Bangalore(int health, int tacticalAbility, int ultimateAbility, int presenceOfWeapons, int damage, int ultimateDamage, int initiative, bool haveBlocking) 
        : base(health, tacticalAbility, ultimateAbility, presenceOfWeapons, damage, ultimateDamage, initiative, haveBlocking)
    {
    }

    public override void MakeAMove(List<Unit> enemyUnits, List<Unit> friendlyUnits)
    {
        Console.WriteLine($"{nameof(Bangalore)} делает ход...");
        if (ProbabilityBy(UltimateAbility))
        {
            AdditionalAttack(enemyUnits[new Random().Next(0,enemyUnits.Count - 1)]);
        }
        else
        {
            Attack(enemyUnits[new Random().Next(0,enemyUnits.Count - 1)]);
        }
    }
    public override void TakeDamage(int valueDamage)
    {
        if (HaveBlocking)
        {
            Console.WriteLine($"У {nameof(Bangalore)} был блок, урон не получен.");
            HaveBlocking = false;
        }
        else
        {
            if (ProbabilityBy(TacticalAbility))
            {
                Console.WriteLine($"{nameof(Bangalore)} выпускает дымовую гранату и не получает урон.");
            }
            else
            {
                base.TakeDamage(valueDamage);
                Console.WriteLine(Health > 0
                    ? $"{nameof(Bangalore)} получила урон, оставшееся здоровье: {Health}/{MaxHealth}."
                    : $"{nameof(Bangalore)} получила урон и умерла.");
            }
        }

    }

    public override void AdditionalAttack(Unit unit)
    {
        Console.WriteLine($"{nameof(Bangalore)} вызывает артиллерийский обстрел. ");
        unit.TakeDamage(UltimateDamage);
    }

    public override void Attack(Unit unit)
    {
        if (ProbabilityBy(PresenceOfWeapons))
        {
            Console.WriteLine($"{nameof(Bangalore)} атакует.");
            unit.TakeDamage(Damage);
        }
        else
        {
            Console.WriteLine($"{nameof(Bangalore)} промахивается.");
        }
    }
}