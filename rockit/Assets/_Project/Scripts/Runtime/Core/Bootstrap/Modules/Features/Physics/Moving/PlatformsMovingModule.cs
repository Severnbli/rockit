using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Features.Physics.Moving.Platforms.Systems;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Physics.Moving
{
    public sealed class PlatformsMovingModule : BaseModule<PlatformsMovingModule>
    {
        public PlatformsMovingModule(IDomain domain) : base(domain)
        {
        }

        protected override void BindSystems()
        {
            base.BindSystems();
            
            BindSystem<SendUpdatePlatformStatesRequestsOnInitializeRequestSystem>();
            BindSystem<UpdatePlatformChangesBufferOnUpdateStatesRequestsSystem>();
            BindSystem<SpecifyPlatformPositionChangeOnRunSystem>();
            BindSystem<SpecifyPlatformRotationChangeOnRunSystem>();
            BindSystem<SpecifyScaleChangeOnRunSystem>();
            BindSystem<MoveRigidbodyPlatformByPlatformPositionChangeSystem>();
            BindSystem<RotateRigidbodyPlatformByPlatformRotationChangeSystem>();
            BindSystem<ScaleRigidbodyPlatformByPlatformScaleChangeSystem>();
            BindSystem<TranslatePlatformsInputPositionToUpdatePlatformPositionRequestSystem>();
        }
    }
}