using _Project.Scripts.Runtime.Features.Graphics.Particles.Components;
using _Project.Scripts.Runtime.Features.Platforms.Shared.Tags;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.Particles
{
    public sealed class ParticlesAspect : ProtoAspectInject
    {
        public readonly ProtoPool<ParticleSystemComponent> ParticleSystemComponentPool;
        public readonly ProtoIt PositionPlatformParticleSystems = new (It.Inc<PositionPlatformTag, ParticleSystemComponent>());
    }
}