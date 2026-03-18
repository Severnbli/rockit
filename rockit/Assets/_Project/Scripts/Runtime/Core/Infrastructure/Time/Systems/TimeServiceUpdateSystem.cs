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
            throw new System.NotImplementedException();
        }

        public void FixedRun()
        {
            throw new System.NotImplementedException();
        }
    }
}