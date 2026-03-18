using _Project.Scripts.Runtime.Core.Infrastructure.Time.Services;
using _Project.Scripts.Runtime.Core.Systems;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Time.Systems
{
    public sealed class TimeServiceUpdateSystem : IProtoRunSystem, IProtoFixedRunSystem
    {
        private TimeService _timeService;

        public TimeServiceUpdateSystem(TimeService timeService)
        {
            _timeService = timeService;
        }

        public void Run()
        {
            _timeService.Time = UnityEngine.Time.time;
            _timeService.DeltaTime = UnityEngine.Time.deltaTime;
            _timeService.UnscaledTime = UnityEngine.Time.unscaledTime;
            _timeService.UnscaledDeltaTime = UnityEngine.Time.unscaledDeltaTime;
        }

        public void FixedRun()
        {
            _timeService.FixedTime = UnityEngine.Time.fixedTime;
            _timeService.FixedDeltaTime = UnityEngine.Time.fixedDeltaTime;
            _timeService.UnscaledFixedTime = UnityEngine.Time.fixedUnscaledTime;
            _timeService.UnscaledFixedDeltaTime = UnityEngine.Time.fixedUnscaledDeltaTime;
        }
    }
}