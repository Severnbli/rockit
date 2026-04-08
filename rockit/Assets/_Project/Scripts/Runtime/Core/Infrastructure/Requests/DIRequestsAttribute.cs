using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Requests
{
    public class DIRequestsAttribute : DIAttribute
    {
        public DIRequestsAttribute() : base(RequestsContracts.Requests) {}
    }
}