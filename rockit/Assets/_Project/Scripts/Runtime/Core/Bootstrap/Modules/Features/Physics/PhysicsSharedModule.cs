using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Features.Physics.Shared.Services;
using _Project.Scripts.Runtime.Features.Physics.Shared.Systems;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Physics
{
    public sealed class PhysicsSharedModule : BaseModule<PhysicsSharedModule>
    {
        public PhysicsSharedModule(IDomain domain) : base(domain)
        {
        }

        protected override void BindServices()
        {
            base.BindServices();
            
            BindService<PhysicsService>();
        }

        protected override void BindSystems()
        {
            base.BindSystems();
            
            BindSystem<PhysicsServiceUpdateSystem>();
        }
    }
}