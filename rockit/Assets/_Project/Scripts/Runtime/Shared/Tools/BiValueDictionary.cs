using System.Collections.Generic;
using _Project.Scripts.Runtime.Shared.Extensions;

namespace _Project.Scripts.Runtime.Shared.Tools
{
    public class BiValueDictionary<TFirst, TSecond, TValue> : BiDictionary<TFirst, TSecond> 
        where TFirst : notnull
        where TSecond : notnull
    {
        protected readonly Dictionary<TFirst, TValue> FirstValues = new ();
        protected readonly Dictionary<TSecond, TValue> SecondValues = new ();

        public bool TrySet(TFirst first, TValue value)
        {
            if (!TryGetByFirst(first, out var second)) return false;
            
            Set(first, second, value);
            return true;
        }
        
        public bool TrySet(TSecond second, TValue value)
        {
            if (!TryGetBySecond(second, out var first)) return false;
            
            Set(first, second, value);
            return true;
        }

        private void Set(TFirst first, TSecond second, TValue value)
        {
            FirstValues.UpdateOrAdd(first, value);
            SecondValues.UpdateOrAdd(second, value);
        }

        public override bool TryRemoveByFirst(TFirst first)
        {
            if (TryGetByFirst(first, out var second)) Remove(first, second);
            
            return base.TryRemoveByFirst(first);
        }

        public override bool TryRemoveBySecond(TSecond second)
        {
            if (TryGetBySecond(second, out var first)) Remove(first, second);
            
            return base.TryRemoveBySecond(second);
        }
        
        private void Remove(TFirst first, TSecond second)
        {
            FirstValues.Remove(first);
            SecondValues.Remove(second);
        }
    }
}