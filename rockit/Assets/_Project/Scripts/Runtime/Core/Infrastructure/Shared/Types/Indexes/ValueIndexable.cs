using System;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Shared.Types.Indexes
{
    [Serializable]
    public class ValueIndexable<T> : Indexable
    {
        public T Value;
    }
}