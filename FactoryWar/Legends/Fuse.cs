using FactoryWar.Entities;

namespace FactoryWar.Legends;

public class Fuse : Assault
{
    public Fuse(int health, int tacticalAbility, int ultimateAbility, int presenceOfWeapons, int damage, int ultimateDamage, int initiative, bool haveBlocking) 
        : base(health, tacticalAbility, ultimateAbility, presenceOfWeapons, damage, ultimateDamage, initiative, haveBlocking)
    {
    }
    public override void MakeAMove(List<Unit> enemyUnits, List<Unit> friendlyUnits)
    {
        Console.WriteLine($"{nameof(Fuse)} делает ход...");
        if (ProbabilityBy(UltimateAbility)){
            AdditionalAttack(enemyUnits[new Random().Next(0,enemyUnits.Count - 1)]);
        }else{
            Attack(enemyUnits[new Random().Next(0,enemyUnits.Count - 1)]);
        }
    }
    public override void AdditionalAttack(Unit unit)
    {
        Console.WriteLine($"{nameof(Fuse)} вызывает бомбадировку.");
        unit.TakeDamage(UltimateDamage);
    }
    public override void TakeDamage(int valueDamage)
    {
        if (HaveBlocking)
        {
            Console.WriteLine($"У {nameof(Fuse)} был блок, урон не получен.");
            HaveBlocking = false;
        }
        else
        {
            base.TakeDamage(valueDamage);
            Console.WriteLine(Health > 0
                ? $"{nameof(Fuse)} получил урон, оставшееся здоровье: {Health}/{MaxHealth}."
                : $"{nameof(Fuse)} получил урон и умер.");
        }
    }

    public override void Attack(Unit unit)
    {
        if (ProbabilityBy(TacticalAbility))
        {
            Console.WriteLine($"{nameof(Fuse)} запустил кластерную бомбу.");
            unit.TakeDamage(Damage*2);
        }else if (ProbabilityBy(PresenceOfWeapons)){
            Console.WriteLine($"{nameof(Fuse)} атакует.");
            unit.TakeDamage(Damage);
        }else
        {
            Console.WriteLine($"{nameof(Fuse)} промахивается.");
        }
    }
}