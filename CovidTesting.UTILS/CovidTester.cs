using System;
using System.Linq;

[assembly: System.CLSCompliant(false)]
namespace CovidTesting.UTILS
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1052:Static holder types should be Static or NotInheritable", Justification = "This needs to be non-static.")]
    public class CovidTester
    {
        private static readonly Random rnd = new ();

        [CovidTestMethod]
        public static bool PcrTester(string input)
        {
            if (input is null) throw new ArgumentNullException(nameof(input), " NULL input param!");
            int num = input.ToUpperInvariant().Count(x => x == 'E') + input.ToUpperInvariant().Count(x => x == 'T');
            return rnd.Next(3 * num) == 0;
        }

        [CovidTestMethod]
        public static bool AntibodyTester(string input)
        {
            if (input is null) throw new ArgumentNullException(nameof(input), " NULL input param!");
            int num = input.ToUpperInvariant().Count(x => x == 'A') + input.ToUpperInvariant().Count(x => x == 'S');
            return rnd.Next(5 * num) == 0;
        }
    }
}
