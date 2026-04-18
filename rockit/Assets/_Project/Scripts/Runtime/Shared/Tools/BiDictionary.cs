using System.Collections.Generic;
using System.Linq;

namespace _Project.Scripts.Runtime.Shared.Tools
{
    public class BiDictionary<TFirst, TSecond> 
        where TFirst : notnull 
        where TSecond : notnull
    {
        private readonly Dictionary<TFirst, TSecond> _forward = new ();
        private readonly Dictionary<TSecond, TFirst> _reverse = new ();

        public virtual bool TryAdd(TFirst first, TSecond second)
        {
            if (_forward.ContainsKey(first) || _reverse.ContainsKey(second)) return false;
            
            _forward.Add(first, second);
            _reverse.Add(second, first);
            return true;
        }

        public virtual bool TryGetByFirst(TFirst first, out TSecond second) => _forward.TryGetValue(first, out second);
        
        public virtual bool TryGetBySecond(TSecond second, out TFirst first) => _reverse.TryGetValue(second, out first);

        public virtual bool TryRemoveByFirst(TFirst first)
        {
            if (!_forward.Remove(first, out var second)) return false;

            _reverse.Remove(second);
            return true;
        }

        public virtual bool TryRemoveBySecond(TSecond second)
        {
            if (_reverse.Remove(second, out var first)) return false;
            
            _forward.Remove(first);
            return true;
        }

        public HashSet<TFirst> GetFirsts() => _forward.Keys.ToHashSet();
        
        public HashSet<TSecond> GetSeconds() => _reverse.Keys.ToHashSet();

        public virtual void KeepOnly(HashSet<TFirst> firsts)
        {
            foreach (var key in _forward.Keys)
            {
                if (firsts.Contains(key)) continue;

                TryRemoveByFirst(key);
            }
        }
        
        public virtual void KeepOnly(HashSet<TSecond> firsts)
        {
            foreach (var key in _reverse.Keys)
            {
                if (firsts.Contains(key)) continue;

                TryRemoveBySecond(key);
            }
        }
    }
}