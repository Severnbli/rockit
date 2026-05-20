using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Features.Graphics.Animations.Checkpoints.Systems;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Graphics.Animations
{
    public sealed class CheckpointsAnimationsModule : BaseModule<CheckpointsAnimationsModule>
    {
        public CheckpointsAnimationsModule(IDomain domain) : base(domain)
        {
        }

        protected override void BindSystems()
        {
            base.BindSystems();
            
            BindSystem<UpdateCheckpointAnimatorActivatedBoolByCheckpointActiveStatusSystem>();
        }
    }
}