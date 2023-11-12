using FactoryWar.Entities;
using FactoryWar.Legends;

namespace FactoryWar;

public class SecondTeamFactory: AbstractFactory
{
    public override Unit CreateSupport()
    {
        return new Lifeline(150, 4, 2, 6, 15, 25, 3, false);
    }

    public override Unit CreateAssault()
    {
        return new Bangalore(150, 5, 3, 6, 25, 65, 1, false);
    }

    public override Unit CreateController()
    {
        return new Rampart(150, 5, 2, 6, 20, 5, 2, false);
    }
}