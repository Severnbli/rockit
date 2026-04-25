using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Features.Graphics.Effects.Glitch.Services;
using _Project.Scripts.Runtime.Features.Graphics.Effects.Glitch.Systems;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Graphics.Effects
{
    public sealed class GlitchEffectsModule : BaseModule<GlitchEffectsModule>
    {
        public GlitchEffectsModule(IDomain domain) : base(domain)
        {
        }

        protected override void BindServices()
        {
            base.BindServices();
            
            BindService<GlitchService>();
        }

        protected override void BindSystems()
        {
            base.BindSystems();
            
            BindSystem<LoadGlitchServiceFeatureOnInitSystem>();
            BindSystem<UpdateGlitchServiceFeatureOnRunSystem>();
        }
    }
}