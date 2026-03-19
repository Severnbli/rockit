using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.Systems;
using _Project.Scripts.Runtime.Core.Systems;
using _Project.Scripts.Runtime.Shared.Extensions;
using NUnit.Framework;

namespace _Project.Scripts.Tests.Systems
{
    public class InfrastructureTests
    {
        private ISystemsContainerProvider _systemsContainerProvider;
        private EcsSystems _systems;

        [OneTimeSetUp]
        private void OneTimeSetUp()
        {
            _systemsContainerProvider = new SystemsContainerProvider();
        }

        [OneTimeTearDown]
        private void OneTimeTearDown()
        {
            _systemsContainerProvider = null;
        }

        [SetUp]
        private void SetUp()
        {
            _systems = _systemsContainerProvider.GetSystemsContainer();
        }

        [TearDown]
        private void TearDown()
        {
            _systems?.Destroy();
            _systems = null;
        }

        [Test]
        public void TestRequestsSystems()
        {
            _systems.AddSystem(new DelActivatedRequestsSystem());
            _systems.AddSystem(new ActivateRequestsSystem());
            
            _systems.Init();

            var requestAspect = _systems.World().Aspect(typeof(RequestsAspect)) as RequestsAspect;

            requestAspect.CreateRequest();
            requestAspect.CreateRequest(fixedRun: true);

            Assert.AreEqual(requestAspect!.RunNotActivated.LenSlow(), 1);
            Assert.AreEqual(requestAspect!.FixedRunNotActivated.LenSlow(), 1);
            Assert.AreEqual(requestAspect!.RunActivated.LenSlow(), 0);
            Assert.AreEqual(requestAspect!.FixedRunActivated.LenSlow(), 0);
            
            _systems.Run();
            _systems.FixedRun();
            
            Assert.AreEqual(requestAspect!.RunNotActivated.LenSlow(), 0);
            Assert.AreEqual(requestAspect!.FixedRunNotActivated.LenSlow(), 0);
            Assert.AreEqual(requestAspect!.RunActivated.LenSlow(), 1);
            Assert.AreEqual(requestAspect!.FixedRunActivated.LenSlow(), 1);
            
            _systems.Run();
            _systems.FixedRun();
            
            Assert.AreEqual(requestAspect!.RunNotActivated.LenSlow(), 0);
            Assert.AreEqual(requestAspect!.FixedRunNotActivated.LenSlow(), 0);
            Assert.AreEqual(requestAspect!.RunActivated.LenSlow(), 0);
            Assert.AreEqual(requestAspect!.FixedRunActivated.LenSlow(), 0);
        }
    }
}