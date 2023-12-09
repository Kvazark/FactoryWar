using FactoryWar;
using FactoryWar.Entities;

public class Program
{
    private static void Main(string[] args)
    {
        var firstTeamFactory = new Arena().GetFactoryArena(Arena.ArenaEnum.firstTeam);
        var secondTeamFactory = new Arena().GetFactoryArena(Arena.ArenaEnum.secondTeam);
        Facade facade = new Facade(firstTeamFactory, secondTeamFactory, 10);
        facade.InitialWar();
    }
}