using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Features.Graphics.Effects.Glitch.Services;

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
    }
}