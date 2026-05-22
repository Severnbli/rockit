using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Features.Graphics.Platforms.Systems;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Graphics
{
    public sealed class PlatformsGraphicsModule : BaseModule<PlatformsGraphicsModule>
    {
        public PlatformsGraphicsModule(IDomain domain) : base(domain)
        {
        }

        protected override void BindSystems()
        {
            base.BindSystems();
            
            BindSystem<CreatePlatformColorChangeTimeoutOnSpriteGlowChangeCompletedRequestSystem>();
            BindSystem<PlatformColorChangeTimeoutExpireSystem>();
            BindSystem<UpdatePositionPlatformColorWithSpriteGlowSystem>();
            BindSystem<UpdateRotationPlatformColorWithSpriteGlowSystem>();
            BindSystem<UpdateScalePlatformColorWithSpriteGlowSystem>();
            BindSystem<ResetPlatformColorChangeOnRunSystem>();
            BindSystem<RemovePlatformColorChangeTimeoutFromInactivePlatformSystem>();
            BindSystem<ResetPlatformColorWithSpriteGlowOnInactivitySystem>();
            BindSystem<RemoveBlockedStatusOnPlatformActivatedRequestSystem>();
        }
    }
}