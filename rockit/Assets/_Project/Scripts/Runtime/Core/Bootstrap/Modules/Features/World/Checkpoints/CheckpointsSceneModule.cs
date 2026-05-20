using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Features.World.Checkpoints.Services;
using _Project.Scripts.Runtime.Features.World.Checkpoints.Systems;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.World.Checkpoints
{
    public sealed class CheckpointsSceneModule : BaseModule<CheckpointsSceneModule>
    {
        public CheckpointsSceneModule(IDomain domain) : base(domain)
        {
        }

        protected override void BindServices()
        {
            base.BindServices();
            
            BindService<CheckpointsService>();
        }

        protected override void BindSystems()
        {
            base.BindSystems();
            
            BindSystem<SendActivateCheckpointRequestByPlayerLocatorSystem>();
        }
    }
}