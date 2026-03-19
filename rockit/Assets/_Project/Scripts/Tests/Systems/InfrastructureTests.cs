using _Project.Scripts.Runtime.Core.Infrastructure.Requests.Systems;
using NUnit.Framework;

namespace _Project.Scripts.Tests.Systems
{
    public class InfrastructureTests
    {
        private ISystemsContainerProvider _systemsContainerProvider;

        [OneTimeSetUp]
        private void SetUp()
        {
            _systemsContainerProvider = new SystemsContainerProvider();
        }

        [OneTimeTearDown]
        private void TearDown()
        {
            _systemsContainerProvider = null;
        }

        [Test]
        public void TestRequestsSystems()
        {
            var systems = _systemsContainerProvider.GetSystemsContainer();

            systems.AddSystem(new DelActivatedRequestsSystem());
        }
    }
}