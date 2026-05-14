using System;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Shared.Types
{
    [Serializable]
    public class ValueIndexable<T> : Indexable
    {
        public T Value;
    }
}