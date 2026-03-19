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
    }
}