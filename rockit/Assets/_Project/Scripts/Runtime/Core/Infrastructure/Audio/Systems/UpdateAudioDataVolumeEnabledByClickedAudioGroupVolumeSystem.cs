using _Project.Scripts.Runtime.Core.Infrastructure.Audio.Configs;
using _Project.Scripts.Runtime.Core.Infrastructure.Storage;
using _Project.Scripts.Runtime.Shared.Utils.Infrastructure;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Audio.Systems
{
    public sealed class UpdateAudioDataVolumeEnabledByClickedAudioGroupVolumeSystem : IProtoRunSystem
    {
        [DI] private readonly AudioAspect _aAspect;
        private readonly DataProvider _dProvider;

        public UpdateAudioDataVolumeEnabledByClickedAudioGroupVolumeSystem(DataProvider dProvider)
        {
            _dProvider = dProvider;
        }

        public void Run()
        {
            foreach (var e in _aAspect.ClickedAudioGroupVolumes)
            {
                ref var agComponent = ref _aAspect.AudioGroupComponentPool.Get(e);
                AudioUtils.SwitchAudioDataVolumeEnabledByAudioGroup(_dProvider, agComponent.Group);
            }
        }
    }
}