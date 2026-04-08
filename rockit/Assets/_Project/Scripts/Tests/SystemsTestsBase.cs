using _Project.Scripts.Runtime.Core.Systems;
using NUnit.Framework;

namespace _Project.Scripts.Tests
{
    public class SystemsTestsBase
    {
        protected ISystemsContainerProvider SystemsContainerProvider;
        protected EcsSystems Systems;

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
        }

        [TearDown]
        public virtual void TearDown()
        {
            Systems?.Destroy();
            Systems = null;
        }
    }
}