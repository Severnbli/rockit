using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Systems;
using Leopotam.EcsProto;
using NUnit.Framework;

namespace _Project.Scripts.Tests.Shared
{
    public class BaseSystemsTests
    {
        protected ISystemsContainerProvider SystemsContainerProvider;
        protected EcsSystems Systems;
        protected DomainAspect MainAspect;
        protected RequestsAspect RequestsAspect;
        protected ProtoWorld MainWorld;
        protected ProtoWorld RequestsWorld;

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
            RequestsAspect =
                Systems.World(RequestsContracts.RequestsIdentifier).Aspect(typeof(RequestsAspect)) as
                    RequestsAspect;
            MainWorld = Systems.World();
            RequestsWorld = Systems.World(RequestsContracts.RequestsIdentifier);
        }

        [TearDown]
        public virtual void TearDown()
        {
            Systems?.Destroy();
            Systems = null;
            MainWorld.Destroy();
            RequestsWorld.Destroy();
        }
    }
}