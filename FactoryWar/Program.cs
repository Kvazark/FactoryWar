using FactoryWar;
using FactoryWar.Entities;

public class Program
{
    private static void Main(string[] args)
    {
        List<string> results = new List<string>();
        for (int i = 0; i < 10; i++)
        {
            var firstTeamFactory = new Arena().GetFactoryArena(Arena.ArenaEnum.firstTeam);
            var secondTeamFactory = new Arena().GetFactoryArena(Arena.ArenaEnum.secondTeam);

            var teamLoFC= new List<Unit> {firstTeamFactory?.CreateSupport(), firstTeamFactory?.CreateAssault(), firstTeamFactory?.CreateController()};
            var teamLiBR = new List<Unit> {secondTeamFactory?.CreateSupport(), secondTeamFactory?.CreateAssault(), secondTeamFactory?.CreateController()};
            results.Add(BattleSimulation(teamLoFC, teamLiBR));
        }
        Console.WriteLine($"Побед 1 команды: {results.Count(e => e.Contains("ЛОБА ФЬЮЗ КАУСТИК"))}\n" +
                          $"Побед 2 команды:  {results.Count(e => e.Contains("ЛАЙФЛАЙН БАНГАЛОР РАМПОРТ"))}");
    }

    private static string BattleSimulation(List<Unit> teamLoFC, List<Unit> teamLiBR)
    {

        teamLoFC.Sort((x, y) => x.Initiative.CompareTo(y.Initiative));
        teamLiBR.Sort((x, y) => x.Initiative.CompareTo(y.Initiative));
            
        var iteratorLoFC = 0;
        var iteratorLiBR = 0;
        var condition = teamLoFC.Count > 0 && teamLiBR.Count > 0;
        for (int i = 0; condition; i++)
        {
            if (i % 2 == 0)
            {
                teamLoFC[iteratorLoFC % teamLoFC.Count].MakeAMove(teamLiBR, teamLoFC);
                CheckCountTeam(teamLiBR);
                iteratorLoFC++;
            }
            else
            {
                teamLiBR[iteratorLiBR % teamLiBR.Count].MakeAMove(teamLoFC, teamLiBR);
                CheckCountTeam(teamLoFC);
                iteratorLiBR++;
            }

            if (teamLiBR.Count == 0 || teamLoFC.Count == 0)
            {
                break;
            }
        }

        string message;
        if (teamLoFC.Count > 0)
        {
            message = "КОМАНДА 'ЛОБА ФЬЮЗ КАУСТИК' ПОБЕДИЛИ!!!!!!!!!!!!!!!!!";
        }
        else
        {
            message = "КОМАНДА 'ЛАЙФЛАЙН БАНГАЛОР РАМПОРТ' ПОБЕДИЛИ!!!!!!!!!!!!!!!!";
        }
        Console.WriteLine(message);
        return message;
    }
    private static void CheckCountTeam(List<Unit> units)
    {
        units.RemoveAll(e => e.Health <= 0);
    }
}