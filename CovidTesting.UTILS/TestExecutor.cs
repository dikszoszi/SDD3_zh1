using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CovidTesting.UTILS
{
    public class TestExecutor
    {
        static Random rnd = new Random();
        private static MethodInfo PickRandomMethod(object covidTester)
        {
            MethodInfo[] methods = covidTester.GetType().GetMethods()
                .Where(x => x.GetCustomAttribute<CovidTestMethodAttribute>() is not null).ToArray();
            return methods[rnd.Next(methods.Length)];
        }
        private static int GetKeyValue(object obj)
        {
            PropertyInfo property = obj.GetType().GetProperties()
                .Single(x => x.GetCustomAttribute<System.ComponentModel.DataAnnotations.KeyAttribute>() is not null);
            return (int)property.GetValue(obj);
        }
        public static Dictionary<int, bool> ExecuteTests(object covidTester, IEnumerable<object> people)
        {
            var output = new Dictionary<int, bool>();
            foreach (object person in people)
            {
                int id = GetKeyValue(person);
                MethodInfo method = PickRandomMethod(covidTester);
                output[id] = (bool)method.Invoke(covidTester, new object[] { person.ToString() });
            }
            return output;
        }
    }
}
