using System;
using System.Collections.Generic;

namespace _Project.Scripts.Runtime.Shared.Extensions
{
    public static class DictionaryExtensions
    {
        public static bool TryGetByAssignableType<T, TSearch>(this Dictionary<Type, T> dict, out TSearch outValue) 
            where TSearch : T
        {
            outValue = default;
            
            foreach (var (type, value) in dict)
            {
                if (!typeof(TSearch).IsAssignableFrom(type)) continue;

                outValue = (TSearch) value;
                return true;
            }
            
            return false;
        }

        public static void UpdateOrAdd<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, TValue value)
        {
            if (dict.TryAdd(key, value)) return;
            
            dict[key] = value;
        }
    }
}