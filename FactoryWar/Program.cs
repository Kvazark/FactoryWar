using FactoryWar;
using FactoryWar.Entities;

public class Program
{
    private static void Main(string[] args)
    {
        List<string> results = new List<string>();
        for (int i = 0; i < 100; i++)
        {
            var firstTeamFactory = new Arena().GetFactoryArena(Arena.ArenaEnum.firstTeam);
            var secondTeamFactory = new Arena().GetFactoryArena(Arena.ArenaEnum.secondTeam);

            var firstTeamUnits= new List<Unit> {firstTeamFactory?.CreateSupport(), firstTeamFactory?.CreateAssault(), firstTeamFactory?.CreateController()};
            var secondTeamUnits = new List<Unit> {secondTeamFactory?.CreateSupport(), secondTeamFactory?.CreateAssault(), secondTeamFactory?.CreateController()};
            results.Add(MakeWar(firstTeamUnits, secondTeamUnits));
        }
            
        Console.WriteLine($"Побед 1 команды: {results.Count(e => e.Contains("1"))}\n" +
                          $"Побед 2 команды:  {results.Count(e => e.Contains("2"))}");
    }

    private static string MakeWar(List<Unit> firstTeamUnits, List<Unit> secondTeamUnits)
    {
        ////
        return null;
    }
}