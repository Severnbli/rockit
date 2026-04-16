using System.Collections.Generic;

namespace _Project.Scripts.Runtime.Shared.Tools
{
    public class BiDictionary<TFirst, TSecond> 
        where TFirst : notnull 
        where TSecond : notnull
    {
        private readonly Dictionary<TFirst, TSecond> _forward = new ();
        private readonly Dictionary<TSecond, TFirst> _reverse = new ();
    }
}