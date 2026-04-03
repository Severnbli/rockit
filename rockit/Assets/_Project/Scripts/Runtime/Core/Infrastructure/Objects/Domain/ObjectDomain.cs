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
            if (Instances.TryGetValue(typeof(TValue), out var instance)) return (TValue) instance;
            
            var newInstance = Instantiator.Instantiate<TValue>();
            Instances.Add(typeof(TValue), newInstance);
            return newInstance;
        }
    }
}