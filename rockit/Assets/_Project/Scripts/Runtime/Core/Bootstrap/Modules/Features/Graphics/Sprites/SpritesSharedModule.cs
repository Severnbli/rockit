using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Features.Graphics.Sprites.Shared.Systems;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Graphics.Sprites
{
    public sealed class SpritesSharedModule : BaseModule<SpritesSharedModule>
    {
        public SpritesSharedModule(IDomain domain) : base(domain)
        {
        }

        protected override void BindSystems()
        {
            base.BindSystems();
            
            BindSystem<UpdateTransformScaleXToFaceAccordingMoveSystem>();
        }
    }
}