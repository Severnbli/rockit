using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Core.Infrastructure.Audio.Systems;
using _Project.Scripts.Runtime.Core.Infrastructure.Audio.Tools.Player;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Infrastructure.Audio
{
    public sealed class AudioProjectModule : BaseModule<AudioProjectModule>
    {
        public AudioProjectModule(IDomain domain) : base(domain)
        {
        }

        protected override void RegisterBindings()
        {
            base.RegisterBindings();

            Container.Bind<IMusicPlayer>().To<MusicPlayer>().AsSingle();
        }

        protected override void BindSystems()
        {
            base.BindSystems();
            
            BindSystem<PlaySfxOnPlaySfxRequestSystem>();
            BindSystem<DespawnSfxAudioSourceByPlayingStatusSystem>();
            BindSystem<PlayMusicOnPlayMusicRequestSystem>();
            BindSystem<UpdateAudioMixerWithAudioDataOnRunSystem>();
        }
    }
}