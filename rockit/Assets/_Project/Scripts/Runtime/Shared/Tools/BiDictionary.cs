using System.Collections.Generic;

namespace _Project.Scripts.Runtime.Shared.Tools
{
    public class BiDictionary<TFirst, TSecond> 
        where TFirst : notnull 
        where TSecond : notnull
    {
        private readonly Dictionary<TFirst, TSecond> _forward = new ();
        private readonly Dictionary<TSecond, TFirst> _reverse = new ();

        public bool TryAdd(TFirst first, TSecond second)
        {
            if (_forward.ContainsKey(first) || _reverse.ContainsKey(second)) return false;
            
            _forward.Add(first, second);
            _reverse.Add(second, first);
            return true;
        }

        public bool TryGetByFirst(TFirst first, out TSecond second) => _forward.TryGetValue(first, out second);
        
        public bool TryGetBySecond(TSecond second, out TFirst first) => _reverse.TryGetValue(second, out first);
    }
}