using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Core.Systems;
using NUnit.Framework;

namespace _Project.Scripts.Tests
{
    public class BaseSystemsTests
    {
        protected ISystemsContainerProvider SystemsContainerProvider;
        protected EcsSystems Systems;
        protected DomainAspect MainAspect;

        [OneTimeSetUp]
        public virtual void OneTimeSetUp()
        {
            SystemsContainerProvider = new SystemsContainerProvider();
        }

        [OneTimeTearDown]
        public virtual void OneTimeTearDown()
        {
            SystemsContainerProvider = null;
        }

        [SetUp]
        public virtual void SetUp()
        {
            Systems = SystemsContainerProvider.GetSystemsContainer();
            MainAspect = Systems.World().Aspect(typeof(DomainAspect)) as DomainAspect;
        }

        [TearDown]
        public virtual void TearDown()
        {
            Systems?.Destroy();
            Systems = null;
        }
    }
}