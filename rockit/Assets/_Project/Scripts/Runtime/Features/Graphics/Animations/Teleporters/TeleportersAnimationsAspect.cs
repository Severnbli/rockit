using _Project.Scripts.Runtime.Features.Graphics.Animations.Shared.Components;
using _Project.Scripts.Runtime.Features.World.Teleporters.Tags;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.Animations.Teleporters
{
    public sealed class TeleportersAnimationsAspect : ProtoAspectInject
    {
        public readonly ProtoIt TeleporterAnimators = new (It.Inc<TeleporterTag, AnimatorComponent>());
    }
}