using System;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Shared.Types.Indexes
{
    [Serializable]
    public class Indexable : IIndexable
    {
        public int Index { get; set; }
    }
}