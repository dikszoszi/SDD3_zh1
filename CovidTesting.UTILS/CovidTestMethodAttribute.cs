using System;

namespace CovidTesting.UTILS
{
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class CovidTestMethodAttribute : Attribute
    {
    }
}
