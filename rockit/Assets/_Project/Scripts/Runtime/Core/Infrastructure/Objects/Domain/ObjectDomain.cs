using System;
using System.Collections.Generic;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Objects.Domain
{
    public class ObjectDomain : IObjectDomain
    {
        protected readonly Dictionary<Type, object> Instances = new ();
        protected readonly IDomainObjectInstantiator Instantiator;

        public ObjectDomain(IDomainObjectInstantiator instantiator)
        {
            Instantiator = instantiator;
        }

        public TValue Get<TValue>()
        {
            return default;
        }
    }
}