using System;

namespace CovidTesting
{
    using System.Collections.Generic;

    public static class MyExtensions
    {
        public static void ToConsole<T>(this IEnumerable<T> input, string str)
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
