using System.Collections.Generic;

namespace _Project.Scripts.Runtime.Shared.Tools
{
    public class BiValueDictionary<TFirst, TSecond, TValue> : BiDictionary<TFirst, TSecond> 
        where TFirst : notnull
        where TSecond : notnull
    {
        protected readonly Dictionary<TFirst, TValue> FirstValues = new ();
        protected readonly Dictionary<TSecond, TValue> SecondValues = new ();
    }
}