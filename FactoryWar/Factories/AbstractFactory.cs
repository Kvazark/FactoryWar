using FactoryWar.Entities;

namespace FactoryWar;

public abstract  class AbstractFactory
{
    public abstract Unit CreateSupport();
    public abstract Unit CreateAssault();
    public abstract Unit CreateController();
}