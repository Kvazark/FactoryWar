using FactoryWar.Entities;

namespace FactoryWar.Legends;

public class Rampart: Controller
{
    public Rampart(int health, int tacticalAbility, int ultimateAbility, int presenceOfWeapons, int damage, int blocking, int initiative, bool haveBlocking) 
        : base(health, tacticalAbility, ultimateAbility, presenceOfWeapons, damage, blocking, initiative, haveBlocking)
    {
    }

    public override void MakeAMove(List<Unit> enemyUnits, List<Unit> friendlyUnits)
    {
        Console.WriteLine($"{nameof(Rampart)} делает ход...");
        if(ProbabilityBy(TacticalAbility)) PutABlock(friendlyUnits[new Random().Next(0,friendlyUnits.Count-1)]);
        else Attack(enemyUnits[new Random().Next(0,enemyUnits.Count-1)]);
    }

    public override void PutABlock(Unit unit)
    {
        if (ProbabilityBy(TacticalAbility))
        {
            unit.HaveBlocking = true;
            if (unit.GetType().Name == nameof(Rampart)) Console.WriteLine($"{nameof(Rampart)} сделала укрпление для себя.");
            else Console.WriteLine($"{nameof(Rampart)} сделала укрепление для {unit.GetType().Name}.");
        }
        else
        {
            Console.WriteLine($"Тактическое умение {nameof(Rampart)} не готово.");
        }
    }
    public override void TakeDamage(int valueDamage)
    {
        if (HaveBlocking)
        {
            Console.WriteLine($"У {nameof(Rampart)} был блок, урон не получен.");
            HaveBlocking = false;
        }
        else
        {
            if(ProbabilityBy(TacticalAbility)) Console.WriteLine($"{nameof(Rampart)} поставила укрытие для себя и не получила урон.");
            else
            {
                base.TakeDamage(valueDamage);
                Console.WriteLine(Health > 0
                    ? $"{nameof(Rampart)} получила урон, оставшееся здоровье: {Health}/{MaxHealth}"
                    : $"{nameof(Rampart)} получила урон и умера");
            }
        }
    }

    public override void Attack(Unit unit)
    {
        if (ProbabilityBy(UltimateAbility))
        {
            Console.WriteLine($"{nameof(Rampart)} ставит пулимёт и атакует.");
            unit.TakeDamage(Damage*2);
        }else if (ProbabilityBy(PresenceOfWeapons))
        {
            Console.WriteLine($"{nameof(Rampart)} атакует.");
            unit.TakeDamage(Damage);
        }else
        {
            Console.WriteLine($"{nameof(Rampart)} промахивается.");
        }
    }
}