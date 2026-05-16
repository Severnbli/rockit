using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Core.Infrastructure.Audio.Systems;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Infrastructure.Audio
{
    public sealed class AudioSceneModule : BaseModule<AudioSceneModule>
    {
        public AudioSceneModule(IDomain domain) : base(domain)
        {
        }

        protected override void BindSystems()
        {
            base.BindSystems();
            
            BindSystem<UpdateAudioDataVolumeEnabledByClickedAudioGroupVolumeSystem>();
        }
    }
}