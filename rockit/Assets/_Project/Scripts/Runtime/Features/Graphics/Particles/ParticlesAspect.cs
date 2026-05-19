using _Project.Scripts.Runtime.Features.Graphics.Particles.Components;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.Particles
{
    public sealed class ParticlesAspect : ProtoAspectInject
    {
        public readonly ProtoPool<ParticleSystemComponent> ParticleSystemComponentPool;
    }
}