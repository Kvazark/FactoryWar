using FactoryWar.Entities;

namespace FactoryWar.Legends;

public class Caustic: Controller
{
    public Caustic(int health, int tacticalAbility, int ultimateAbility, int presenceOfWeapons, int damage, int blocking, int initiative, bool haveBlocking) 
        : base(health, tacticalAbility, ultimateAbility, presenceOfWeapons, damage, blocking, initiative, haveBlocking)
    {
    }

    public override void MakeAMove(List<Unit> enemyUnits, List<Unit> friendlyUnits)
    {
        Console.WriteLine($"{nameof(Caustic)} делает ход...");
        if(ProbabilityBy(TacticalAbility)) PutABlock(friendlyUnits[new Random().Next(0,friendlyUnits.Count-1)]);
        else Attack(enemyUnits[new Random().Next(0,enemyUnits.Count-1)]);
    }

    public override void PutABlock(Unit unit)
    {
        if (ProbabilityBy(TacticalAbility))
        {
            unit.HaveBlocking = true;
            if (unit.GetType().Name == nameof(Caustic)) Console.WriteLine($"{nameof(Caustic)} сделал укрпление для себя.");
            else Console.WriteLine($"{nameof(Caustic)} сделала укрпление для {unit.GetType().Name}.");
        }
        else
        {
            Console.WriteLine($"Тактическое умение {nameof(Caustic)} не готово.");
        }
    }
    public override void TakeDamage(int valueDamage)
    {
        if (HaveBlocking)
        {
            Console.WriteLine($"У {nameof(Caustic)} был блок, урон не получен.");
            HaveBlocking = false;
        }
        else
        {
            if(ProbabilityBy(TacticalAbility)) Console.WriteLine($"{nameof(Caustic)} поставил укрытие для себя и не получил урон.");
            else
            {
                base.TakeDamage(valueDamage);
                Console.WriteLine(Health > 0
                    ? $"{nameof(Caustic)} получил урон, оставшееся здоровье: {Health}/{MaxHealth}"
                    : $"{nameof(Caustic)} получил урон и умер");
            }
        }
    }

    public override void Attack(Unit unit)
    {
        if (ProbabilityBy(UltimateAbility))
        {
            Console.WriteLine($"{nameof(Caustic)} атакует газовой бомбой.");
            unit.TakeDamage(Damage*2);
        }else if (ProbabilityBy(PresenceOfWeapons))
        {
            Console.WriteLine($"{nameof(Caustic)} атакует.");
            unit.TakeDamage(Damage);
        }else
        {
            Console.WriteLine($"{nameof(Caustic)} промахивается.");
        }
    }
}