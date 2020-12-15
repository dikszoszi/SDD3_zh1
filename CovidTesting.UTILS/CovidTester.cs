using System;
using System.Linq;

namespace CovidTesting.UTILS
{
    public class CovidTester
    {
        static Random rnd = new Random();

        [CovidTestMethod]
        public static bool PcrTester(string input)
        {
            int num = input.ToUpper().Count(x => x == 'E') + input.ToUpper().Count(x => x == 'T');
            return rnd.Next(3 * num) == 0;
        }

        [CovidTestMethod]
        public static bool AntibodyTester(string input)
        {
            int num = input.ToUpper().Count(x => x == 'A') + input.ToUpper().Count(x => x == 'S');
            return rnd.Next(5 * num) == 0;
        }
    }
}
