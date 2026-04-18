using System.Collections.Generic;
using System.Linq;

namespace _Project.Scripts.Runtime.Shared.Tools
{
    public class BiDictionary<TFirst, TSecond> 
        where TFirst : notnull 
        where TSecond : notnull
    {
        protected readonly Dictionary<TFirst, TSecond> Forward = new ();
        private readonly Dictionary<TSecond, TFirst> _reverse = new ();

        public bool TryAdd(TFirst first, TSecond second)
        {
            if (Forward.ContainsKey(first) || _reverse.ContainsKey(second)) return false;
            
            Forward.Add(first, second);
            _reverse.Add(second, first);
            return true;
        }

        public bool TryGetByFirst(TFirst first, out TSecond second) => Forward.TryGetValue(first, out second);
        
        public bool TryGetBySecond(TSecond second, out TFirst first) => _reverse.TryGetValue(second, out first);

        public bool TryRemoveByFirst(TFirst first)
        {
            if (!Forward.Remove(first, out var second)) return false;

            _reverse.Remove(second);
            return true;
        }

        public bool TryRemoveBySecond(TSecond second)
        {
            if (_reverse.Remove(second, out var first)) return false;
            
            Forward.Remove(first);
            return true;
        }

        public HashSet<TFirst> GetFirsts() => Forward.Keys.ToHashSet();
        
        public HashSet<TSecond> GetSeconds() => _reverse.Keys.ToHashSet();

        public void KeepOnly(HashSet<TFirst> firsts)
        {
            foreach (var key in Forward.Keys)
            {
                if (firsts.Contains(key)) continue;

                TryRemoveByFirst(key);
            }
        }
        
        public void KeepOnly(HashSet<TSecond> firsts)
        {
            foreach (var key in _reverse.Keys)
            {
                if (firsts.Contains(key)) continue;

                TryRemoveBySecond(key);
            }
        }
    }
}