using _Project.Scripts.Runtime.Core.Infrastructure.Shared;
using _Project.Scripts.Runtime.Core.Infrastructure.Storage;
using _Project.Scripts.Runtime.Shared.Utils.Infrastructure;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Audio.Systems
{
    public sealed class UpdateOpenableClosableAudioGroupVolumeOpenStatusByAudioDataVolumeEnabledSystem : IProtoRunSystem
    {
        [DI] private readonly AudioAspect _aAspect;
        [DI] private readonly SharedAspect _sAspect;
        private readonly DataProvider _dProvider;

        public UpdateOpenableClosableAudioGroupVolumeOpenStatusByAudioDataVolumeEnabledSystem(DataProvider dProvider)
        {
            _dProvider = dProvider;
        }

        public void Run()
        {
            foreach (var e in _aAspect.OpenableClosableAudioGroupVolumes)
            {
                ref var agComponent = ref _aAspect.AudioGroupComponentPool.Get(e);
                ref var ocComponent = ref _sAspect.OpenableClosableComponentPool.Get(e);

                var enabled = AudioUtils.GetAudioDataVolumeEnabledByAudioGroup(_dProvider, agComponent.Group);
                ocComponent.OpenableClosable.SetStatus(enabled);
            }
        }
    }
}