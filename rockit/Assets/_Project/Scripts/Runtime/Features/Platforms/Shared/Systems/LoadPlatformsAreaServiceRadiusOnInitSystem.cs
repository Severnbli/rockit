using _Project.Scripts.Runtime.Features.Platforms.Shared.Configs;
using _Project.Scripts.Runtime.Features.Platforms.Shared.Services;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Platforms.Shared.Systems
{
    public sealed class LoadPlatformsAreaServiceRadiusOnInitSystem : IProtoInitSystem
    {
        private readonly PlatformsAreaService _paService;
        private readonly PlatformsAreaConfig _paConfig;

        public LoadPlatformsAreaServiceRadiusOnInitSystem(PlatformsAreaService paService, PlatformsAreaConfig paConfig)
        {
            _paService = paService;
            _paConfig = paConfig;
        }

        public void Init(IProtoSystems systems)
        {
            _paService.Radius = _paConfig.Radius;
        }
    }
}