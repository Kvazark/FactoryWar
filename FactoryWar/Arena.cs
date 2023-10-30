namespace FactoryWar;

public class Arena
{
    public enum ArenaEnum
    {
        firstTeam = 1,
        secondTeam = 2
    }
    public AbstractFactory? GetFactoryArena(ArenaEnum arena)
    {
        AbstractFactory? result = null;
        switch (arena)
        {
            case ArenaEnum.firstTeam:
            {
                result = new FirstTeamFactory();
                break;
            }
            case ArenaEnum.secondTeam:
            {
                result = new SecondTeamFactory();
                break;
            }
        }

        return result;
    }
}