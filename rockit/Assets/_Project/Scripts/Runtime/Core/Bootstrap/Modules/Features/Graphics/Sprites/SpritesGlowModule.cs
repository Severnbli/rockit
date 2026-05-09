using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Features.Graphics.Sprites.Glow.Systems;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Graphics.Sprites
{
    public sealed class SpritesGlowModule : BaseModule<SpritesGlowModule>
    {
        public SpritesGlowModule(IDomain domain) : base(domain)
        {
        }

        protected override void BindSystems()
        {
            base.BindSystems();
            
            BindSystem<CompleteSpriteGlowChangeOnRunSystem>();
            BindSystem<UpdateSpriteGlowBySpriteGlowChangeComponentSystem>();
        }
    }
}