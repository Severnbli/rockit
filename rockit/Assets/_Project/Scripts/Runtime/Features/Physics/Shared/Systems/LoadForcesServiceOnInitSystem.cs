using _Project.Scripts.Runtime.Features.Physics.Shared.Configs;
using _Project.Scripts.Runtime.Features.Physics.Shared.Services;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Physics.Shared.Systems
{
    public sealed class LoadForcesServiceOnInitSystem : IProtoInitSystem
    {
        private readonly ForcesService _fService;
        private readonly PhysicsSharedConfig _psConfig;

        public LoadForcesServiceOnInitSystem(ForcesService fService, PhysicsSharedConfig psConfig)
        {
            _fService = fService;
            _psConfig = psConfig;
        }

        public void Init(IProtoSystems systems)
        {
            _fService.GravityScale = _psConfig.InitialGravityScale;
        }
    }
}