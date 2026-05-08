using _Project.Scripts.Runtime.Core.Infrastructure.Audio.Tools.Player;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Audio.Systems
{
    public sealed class PlayMusicOnPlayMusicRequestSystem : IProtoRunSystem
    {
        [DIRequests] private readonly AudioRequestsAspect _arAspect;
        private readonly IMusicPlayer _mPlayer;

        public PlayMusicOnPlayMusicRequestSystem(IMusicPlayer mPlayer)
        {
            _mPlayer = mPlayer;
        }

        public void Run()
        {
            var (reqE, ok) = _arAspect.PlayMusicRequests.FirstSlow();
            if (!ok) return;
            
            ref var pmRequest = ref _arAspect.PlayMusicRequestPool.Get(reqE);
            _mPlayer.Play(pmRequest.Clip, pmRequest.Looped);
        }
    }
}