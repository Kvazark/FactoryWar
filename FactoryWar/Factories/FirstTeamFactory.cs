using FactoryWar.Entities;
using FactoryWar.Legends;

namespace FactoryWar;

public class FirstTeamFactory  : AbstractFactory
{
    public override Unit CreateSupport()
    {
        return new Loba(150, 6,4,6,18,30, 3, false);
    }

    public override Unit CreateAssault()
    {
        return new Fuse(150, 4,3,6,25,60, 1, false);
    }

    public override Unit CreateController()
    {
        return new Caustic(150, 5,3,6,20,7, 2, false);
    }
}