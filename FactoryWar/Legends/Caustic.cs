using FactoryWar.Entities;

namespace FactoryWar.Legends;

public class Caustic: Controller
{
    public Caustic(int health, int tacticalAbility, int ultimateAbility, int damage, int blocking) : base(health, tacticalAbility, ultimateAbility, damage, blocking)
    {
    }

    public override void MakeAMove(List<Unit> enemyUnits, List<Unit> friendlyUnits)
    {
        Console.WriteLine($"{nameof(Caustic)} делает ход");
        if(ProbabilityBy(TacticalAbility)) PutABlock(friendlyUnits[new Random().Next(0,friendlyUnits.Count-1)]);
        else Attack(enemyUnits[new Random().Next(0,enemyUnits.Count-1)]);
    }

    public override void PutABlock(Unit unit)
    {
        if (ProbabilityBy(TacticalAbility))
        {
            Console.WriteLine($"{nameof(Caustic)} сделал укрпление для всех");
        }
        else
        {
            base.TakeAttack(10);
            Console.WriteLine($"{nameof(Caustic)} получил урон, оставшееся здоровье: {Health}/{MaxHealth}");
        }
    }
    public override void TakeAttack(int valueDamage)
    {
        base.TakeAttack(valueDamage);
        Console.WriteLine(Health > 0
            ? $"{nameof(Caustic)} получил урон, оставшееся здоровье: {Health}/{MaxHealth}"
            : $"{nameof(Caustic)} получил урон и умер");
    }

    public override void Attack(Unit unit)
    {
        if (ProbabilityBy(UltimateAbility))
        {
            Console.WriteLine($"{nameof(Caustic)} атакует");
            unit.TakeAttack(Damage);
        }
        else
        {
            Console.WriteLine($"{nameof(Caustic)} промахивается");
        }
    }
}