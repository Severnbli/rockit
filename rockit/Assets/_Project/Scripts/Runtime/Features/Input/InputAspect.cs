using _Project.Scripts.Runtime.Features.Input.Requests;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Input
{
    public class InputAspect : ProtoAspectInject
    {
        public ProtoPool<EnablePlayerInputRequest> EnablePlayerInputRequestPool;
        public ProtoPool<DisablePlayerInputRequest> DisablePlayerInputRequestPool;
    }
}