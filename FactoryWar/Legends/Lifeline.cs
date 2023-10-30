using FactoryWar.Entities;

namespace FactoryWar.Legends;

public class Lifeline: Support
{
    public Lifeline(int health, int tacticalAbility, int ultimateAbility, int treatment, int dexterity) : base(health, tacticalAbility, ultimateAbility, treatment, dexterity)
    {
    }

    public override void MakeAMove(List<Unit> enemyUnits, List<Unit> friendlyUnits)
    {
        Console.WriteLine($"{nameof(Lifeline)} делает ход");
        if (ProbabilityBy(Treatment)) Heal(friendlyUnits[new Random().Next(0,friendlyUnits.Count - 1)]);
        else GroupHeal(friendlyUnits);
    }
    public override void TakeAttack(int valueDamage)
    {
        base.TakeAttack(valueDamage);
        Console.WriteLine(Health > 0
            ? $"{nameof(Lifeline)} получила урон, оставшееся здоровье: {Health}/{MaxHealth}"
            : $"{nameof(Lifeline)} получила урон и умерла");
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
                message = $"{nameof(Lifeline)} вылечила {unit.GetType().Name} на {Treatment}";
            }
            else
            {
                unit.Health += valueIncrease;
                message = $"{nameof(Lifeline)} вылечила {unit.GetType().Name} на {valueIncrease}";
            }
        }
        else
        {
            message = $"{nameof(Lifeline)} промахнулась и не вылечилась {unit.GetType().Name}";
        }
        Console.WriteLine(message);
    }

    public override void GroupHeal(List<Unit> units)
    {
        Console.WriteLine($"{nameof(Lifeline)} захиллила всю команду");
        units.ForEach(Heal);
    }
}