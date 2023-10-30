using FactoryWar.Entities;

namespace FactoryWar.Legends;

public class Rampart: Controller
{
    public Rampart(int health, int tacticalAbility, int ultimateAbility, int damage, int blocking) : base(health, tacticalAbility, ultimateAbility, damage, blocking)
    {
    }

    public override void MakeAMove(List<Unit> enemyUnits, List<Unit> friendlyUnits)
    {
        Console.WriteLine($"{nameof(Rampart)} делает ход");
        if(ProbabilityBy(TacticalAbility)) PutABlock(friendlyUnits[new Random().Next(0,friendlyUnits.Count-1)]);
        else Attack(enemyUnits[new Random().Next(0,enemyUnits.Count-1)]);
    }

    public override void PutABlock(Unit unit)
    {
        if (ProbabilityBy(TacticalAbility))
        {
            Console.WriteLine($"{nameof(Rampart)} сделала укрепление для всех");
        }
        else
        {
            base.TakeAttack(25);
        }
    }

    public override void TakeAttack(int valueDamage)
    {
        base.TakeAttack(valueDamage);
        Console.WriteLine(Health > 0
            ? $"{nameof(Rampart)} получила урон, оставшееся здоровье: {Health}/{MaxHealth}"
            : $"{nameof(Rampart)} получила урон и умерла");
    }
    public override void Attack(Unit unit)
    {
        if (ProbabilityBy(UltimateAbility))
        {
            Console.WriteLine($"{nameof(Rampart)} атакует");
            unit.TakeAttack(Damage);
        }
        else
        {
            Console.WriteLine($"{nameof(Rampart)} промахивается");
        }
    }
}