using System.Collections.Generic;
using _Project.Scripts.Runtime.Core.Infrastructure.Objects.Domain;
using NUnit.Framework;
using UnityEditor.VersionControl;
using Zenject;

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
            Assert.Equals(item1, item2);
        }
    }
}