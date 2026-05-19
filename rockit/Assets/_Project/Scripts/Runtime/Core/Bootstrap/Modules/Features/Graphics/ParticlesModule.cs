using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Features.Graphics.Particles.Systems;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Graphics
{
    public sealed class ParticlesModule : BaseModule<ParticlesModule>
    {
        public ParticlesModule(IDomain domain) : base(domain)
        {
        }

        protected override void BindSystems()
        {
            base.BindSystems();
            
            BindSystem<PlayPositionPlatformParticleSystemOnPositionPlatformTriggeredRequestSystem>();
            BindSystem<PlayRotationPlatformParticleSystemOnRotationPlatformTriggeredRequestSystem>();
        }
    }
}