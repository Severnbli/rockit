using _Project.Scripts.Runtime.Features.Graphics.Particles.Components;
using _Project.Scripts.Runtime.Features.Graphics.Particles.Tags;
using _Project.Scripts.Runtime.Features.Platforms.Shared.Tags;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.Particles
{
    public sealed class ParticlesAspect : ProtoAspectInject
    {
        public readonly ProtoPool<ParticleSystemComponent> ParticleSystemComponentPool;
        public readonly ProtoPool<ActiveParticleSystemTag> ActiveParticleSystemTagPool;
        public readonly ProtoIt PositionPlatformParticleSystems = new (It.Inc<PositionPlatformTag, ParticleSystemComponent>());
        public readonly ProtoIt RotationPlatformParticleSystems = new (It.Inc<RotationPlatformTag, ParticleSystemComponent>());
        public readonly ProtoIt ScalePlatformParticleSystems = new (It.Inc<ScalePlatformTag, ParticleSystemComponent>());
        public readonly ProtoIt ActivePositionPlatformParticleSystems = new (It.Inc<ActiveParticleSystemTag, PositionPlatformTag, ParticleSystemComponent>());
        public readonly ProtoIt ActiveRotationPlatformParticleSystems = new (It.Inc<ActiveParticleSystemTag, RotationPlatformTag, ParticleSystemComponent>());
        public readonly ProtoIt ActiveScalePlatformParticleSystems = new (It.Inc<ActiveParticleSystemTag, ScalePlatformTag, ParticleSystemComponent>());
    }
}