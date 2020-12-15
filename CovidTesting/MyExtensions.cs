using System;

namespace CovidTesting
{
    public static class MyExtensions
    {
        public static void ToConsole<T>(this System.Collections.Generic.IEnumerable<T> input, string str)
        {
            if (input is null)
            {
                Console.WriteLine("Nothing to print!");
                return;
            }

            Console.WriteLine("*** BEGIN " + str);
            foreach (T item in input)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("*** END " + str + "\nPress Enter");
            Console.ReadLine();
        }
    }
}
