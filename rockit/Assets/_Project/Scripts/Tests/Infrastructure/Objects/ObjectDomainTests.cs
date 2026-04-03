using _Project.Scripts.Runtime.Core.Infrastructure.Objects.Domain;
using NUnit.Framework;
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
        }
    }
}