using CovidTesting.DB;
using CovidTesting.UTILS;
using System;
using System.Linq;

[assembly: System.CLSCompliant(false)]
namespace CovidTesting
{

    class Program
    {
        static void FillDatabase(PlayerContext ctx)
        {
            TeamGenerator team = new TeamGenerator();
            var teamXml = team.GetTeam(10);
            Console.WriteLine(teamXml);
            Console.ReadLine();

            foreach (var node in teamXml.Descendants("player"))
            {
                Player player = new Player(node);
                ctx.Players.Add(player);
            }
            ctx.SaveChanges();

            CovidTester tester = new CovidTester();
            for (int i = 0; i < 10; i++)
            {
                var results = TestExecutor.ExecuteTests(tester, ctx.Players);
                foreach (var item in results)
                {
                    CovidTest test = new CovidTest
                    {
                        Date = DateTime.Now.Date.AddDays(i * 5),
                        PlayerId = item.Key,
                        IsPositive = item.Value,
                    };
                    ctx.CovidTests.Add(test);
                }
                ctx.SaveChanges();
            }
        }

        private static void QueryDatabase(PlayerContext ctx)
        {
            Console.WriteLine("PLAYERS: " + ctx.Players.Count());
            Console.WriteLine("TESTS: " + ctx.CovidTests.Count());
            Console.ReadLine();

            //var q1 = from test in ctx.CovidTests
            //         group test by test.IsPositive into grp
            //         select new { IsPositive = grp.Key, Number = grp.Count() };
            //q1.ToConsole("Q1");

            var q1a = ctx.Set<CovidTest>().GroupBy(test => test.IsPositive)
                 .Select(group => $"Result: {(group.Key ? "Positive" : "Negative")}\tCount: {group.Count()}")
                 .ToList();
            q1a.ToConsole("Q1 alt.");

            //var q2 = from test in ctx.CovidTests
            //         where test.IsPositive
            //         group test by new { test.Player.Position } into grp
            //         select new { grp.Key.Position, Number = grp.Count() };
            //q2.ToConsole("Q2");

            var q2a = ctx.Set<CovidTest>().Where(test => test.IsPositive).GroupBy(test => test.Player.Position)
                .Select(group => new { Position = group.Key, Number = group.Count() })
                .ToList();
            q2a.ToConsole("Q2 alt.");

            //var q3 = from test in ctx.CovidTests
            //         join player in ctx.Players on test.PlayerId equals player.Id
            //         select new { testId = test.Id, test.Date, test.IsPositive, player.Code };
            //q3.ToConsole("Q3");

            var q3a = ctx.Set<CovidTest>()
                .Join(ctx.Set<Player>(), test => test.PlayerId, player => player.Id, (test, player) => new { test.Id, test.Date, test.IsPositive, player.Code });
            q3a.ToConsole("Q3 alt.");
        }

        private static void Main()
        {
            PlayerContext ctx = new PlayerContext();
            FillDatabase(ctx);
            QueryDatabase(ctx);
            ctx.Dispose();
        }
    }
}
