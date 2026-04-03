using System;
using System.Collections.Generic;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Objects.Domain
{
    public class ObjectDomain : IObjectDomain
    {
        protected readonly Dictionary<Type, object> Instances = new ();
        
        public TValue Get<TValue>()
        {
            return default;
        }
    }
}