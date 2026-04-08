using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Requests.World
{
    public class DIRequestsAttribute : DIAttribute
    {
        public DIRequestsAttribute() : base(RequestsContracts.RequestsIdentifier) {}
    }
}