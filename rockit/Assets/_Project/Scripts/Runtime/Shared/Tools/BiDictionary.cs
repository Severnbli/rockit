using System.Collections.Generic;
using System.Linq;

namespace _Project.Scripts.Runtime.Shared.Tools
{
    public class BiDictionary<TFirst, TSecond> 
        where TFirst : notnull 
        where TSecond : notnull
    {
        protected readonly Dictionary<TFirst, TSecond> Forward = new ();
        protected readonly Dictionary<TSecond, TFirst> Reverse = new ();

        public bool TryAdd(TFirst first, TSecond second)
        {
            if (Forward.ContainsKey(first) || Reverse.ContainsKey(second)) return false;
            
            Forward.Add(first, second);
            Reverse.Add(second, first);
            return true;
        }

        public bool TryGetByFirst(TFirst first, out TSecond second) => Forward.TryGetValue(first, out second);
        
        public bool TryGetBySecond(TSecond second, out TFirst first) => Reverse.TryGetValue(second, out first);

        public bool TryRemoveByFirst(TFirst first)
        {
            if (!Forward.Remove(first, out var second)) return false;

            Reverse.Remove(second);
            return true;
        }

        public bool TryRemoveBySecond(TSecond second)
        {
            if (Reverse.Remove(second, out var first)) return false;
            
            Forward.Remove(first);
            return true;
        }

        public HashSet<TFirst> GetFirsts() => Forward.Keys.ToHashSet();
        
        public HashSet<TSecond> GetSeconds() => Reverse.Keys.ToHashSet();

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
            foreach (var key in Reverse.Keys)
            {
                if (firsts.Contains(key)) continue;

                TryRemoveBySecond(key);
            }
        }
    }
}