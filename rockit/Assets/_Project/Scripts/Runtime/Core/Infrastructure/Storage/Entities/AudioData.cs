using System;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Storage.Entities
{
    [Serializable]
    public sealed class AudioData
    {
        public bool MasterAudioEnabled = true;
        public bool MusicEnabled = true;
        public bool SfxEnabled = true;
    }
}