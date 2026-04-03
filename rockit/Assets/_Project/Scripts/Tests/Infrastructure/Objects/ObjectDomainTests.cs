using System.Collections.Generic;
using _Project.Scripts.Runtime.Core.Infrastructure.Objects.Domain;
using _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle.Pools.Collections;
using NUnit.Framework;
using UnityEngine;
using Zenject;
using ListPool = _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle.Pools.Collections.ListPool<int>;

namespace _Project.Scripts.Tests.Infrastructure.Objects
{
    public class ObjectDomainTests : ZenjectUnitTestFixture
    {
        private IObjectDomain _objectDomain;
        private IDomainObjectInstantiator _instantiator;
        
        [SetUp]
        public override void Setup()
        {
            base.Setup();
            
            _instantiator = new DiContainerDomainObjectInstantiator(Container);
            _objectDomain = new ObjectDomain(_instantiator);
        }

        [Test]
        public void TestObjectDomainInstantiateAbility()
        {
            Assert.NotNull(_objectDomain.Get<List<int>>());
        }
        
        [Test]
        public void TestObjectDomainGiveSameObjectOnEachSameRequest()
        {
            var item1 = _objectDomain.Get<List<int>>();
            var item2 = _objectDomain.Get<List<int>>();
            Assert.AreEqual(item1, item2);
        }

        [Test]
        public void TestNoParameterlessConstructorObjectDomainInstantiate()
        {
            Assert.Throws<ZenjectException>(() => _objectDomain.Get<ListPool>());

            var so = ScriptableObject.CreateInstance<CollectionsPoolsConfig>();
            Container.Bind<CollectionsPoolsConfig>().FromInstance(so);

            ListPool listPool = null;
            Assert.DoesNotThrow(() => listPool = _objectDomain.Get<ListPool>());
            Assert.AreNotEqual(listPool, null);
        }
    }
}