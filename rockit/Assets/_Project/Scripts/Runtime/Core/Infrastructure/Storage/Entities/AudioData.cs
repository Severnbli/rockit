using System;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Storage.Entities
{
    [Serializable]
    public sealed class AudioData
    {
        public bool MasterVolumeEnabled = true;
        public bool MusicVolumeEnabled = true;
        public bool SfxVolumeEnabled = true;
    }
}