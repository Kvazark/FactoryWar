using FactoryWar.Entities;
using FactoryWar.Legends;

namespace FactoryWar;

public class SecondTeamFactory: AbstractFactory
{
    public override Unit CreateSupport()
    {
        return new Lifeline(150, 80, 50, 85, 20);
    }

    public override Unit CreateAssault()
    {
        return new Bangalore(150, 80, 50, 85, 20);
    }

    public override Unit CreateController()
    {
        return new Rampart(150, 80, 50, 85, 20);
    }
}