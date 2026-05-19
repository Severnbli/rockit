using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Audio.Tools.Player
{
    public interface IPlayable
    {
        void Play(AudioClip clip, bool looped = true);
        void Pause();
        void Resume();
        void Stop();
    }
}