using _Project.Scripts.Runtime.Features.Graphics.Cameras;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.Shared
{
    public sealed class GraphicsSharedRequestsAspect : ProtoAspectInject
    {
        public readonly CamerasRequestsAspect CamerasRequestsAspect;
    }
}