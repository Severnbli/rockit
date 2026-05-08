using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Core.Infrastructure.Audio.Systems;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Infrastructure
{
    public sealed class AudioModule : BaseModule<AudioModule>
    {
        public AudioModule(IDomain domain) : base(domain)
        {
        }

        protected override void BindSystems()
        {
            base.BindSystems();
            
            BindSystem<PlaySfxOnPlaySfxRequestSystem>();
            BindSystem<DespawnSfxAudioSourceByPlayingStatusSystem>();
        }
    }
}