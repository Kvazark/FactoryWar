using FactoryWar.Entities;

namespace FactoryWar.Legends;

public class Loba: Support
{
    public Loba(int health, int tacticalAbility, int ultimateAbility, int treatment, int dexterity) : base(health, tacticalAbility, ultimateAbility, treatment, dexterity)
    {
    }

    public override void MakeAMove(List<Unit> enemyUnits, List<Unit> friendlyUnits)
    {
        Console.WriteLine($"{nameof(Loba)} делает ход");
        if (ProbabilityBy(TacticalAbility)) Heal(friendlyUnits[new Random().Next(0,friendlyUnits.Count - 1)]);
        else GroupHeal(friendlyUnits);
    }
    public override void TakeAttack(int valueDamage)
    {
        if (ProbabilityBy(TacticalAbility))
        {
            Console.WriteLine($"{nameof(Loba)} телепортируется");
        }
        else
        {
            base.TakeAttack(valueDamage);
            Console.WriteLine(Health > 0
                ? $"{nameof(Loba)} получила урон, оставшееся здоровье: {Health}/{MaxHealth}"
                : $"{nameof(Loba)} получила урон и умерла");
        }

    }
    public override void Heal(Unit unit)
    {
        string message;
        if (ProbabilityBy(Dexterity))
        {
            var valueIncrease = unit.MaxHealth - unit.Health;
            if (valueIncrease >= Treatment)
            {
                unit.Health += Treatment;
                message = $"{nameof(Loba)} вылечила {unit.GetType().Name} на {Treatment}";
            }
            else
            {
                unit.Health += valueIncrease;
                message = $"{nameof(Loba)}  {unit.GetType().Name} на {valueIncrease}";
            }
        }
        else
        {
            message = $"{nameof(Loba)} промахнулась и не вылечилась {unit.GetType().Name}";
        }
        Console.WriteLine(message);
    }

    public override void GroupHeal(List<Unit> units)
    {
        throw new NotImplementedException();
    }
}