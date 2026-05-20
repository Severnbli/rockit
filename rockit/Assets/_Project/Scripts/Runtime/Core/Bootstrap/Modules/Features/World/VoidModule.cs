using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Features.World.Void.Systems;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.World
{
    public sealed class VoidModule : BaseModule<VoidModule>
    {
        public VoidModule(IDomain domain) : base(domain)
        {
        }

        protected override void BindSystems()
        {
            base.BindSystems();
            
            BindSystem<SwitchToVoidStateOnPlayerTriggeredVoidRequestSystem>();
        }
    }
}