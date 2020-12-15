using System;

namespace CovidTesting
{
    public static class Extensions
    {
        public static void ToConsole<T>(this System.Collections.Generic.IEnumerable<T> input, string str)
        {
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
