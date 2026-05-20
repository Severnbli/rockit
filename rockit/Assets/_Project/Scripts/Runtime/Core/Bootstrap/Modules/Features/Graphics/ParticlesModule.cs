using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Features.Graphics.Particles.Systems;
using _Project.Scripts.Runtime.Features.Graphics.Particles.Types;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Graphics
{
    public sealed class ParticlesModule : BaseModule<ParticlesModule>
    {
        public ParticlesModule(IDomain domain) : base(domain)
        {
        }

        protected override void RegisterBindings()
        {
            base.RegisterBindings();

            Container.Bind<PositionPlatformParticleSystemPool>().ToSelf().AsSingle();
            Container.Bind<RotationPlatformParticleSystemPool>().ToSelf().AsSingle();
            Container.Bind<ScalePlatformParticleSystemPool>().ToSelf().AsSingle();
        }

        protected override void BindSystems()
        {
            base.BindSystems();
            
            BindSystem<PlayPositionPlatformParticleSystemOnPositionPlatformTriggeredRequestSystem>();
            BindSystem<PlayRotationPlatformParticleSystemOnRotationPlatformTriggeredRequestSystem>();
            BindSystem<PlayScalePlatformParticleSystemOnScalePlatformTriggeredRequestSystem>();
        }
    }
}