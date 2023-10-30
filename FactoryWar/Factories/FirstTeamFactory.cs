using FactoryWar.Entities;
using FactoryWar.Legends;

namespace FactoryWar;

public class FirstTeamFactory  : AbstractFactory
{
    public override Unit CreateSupport()
    {
        return new Loba(150, 80, 50, 85, 20);
    }

    public override Unit CreateAssault()
    {
        return new Fuse(150, 80, 50, 85, 20);
    }

    public override Unit CreateController()
    {
        return new Caustic(150, 80, 50, 85, 20);
    }
}