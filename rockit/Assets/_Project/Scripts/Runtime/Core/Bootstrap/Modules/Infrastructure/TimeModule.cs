using _Project.Scripts.Runtime.Core.Systems;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Infrastructure
{
    public sealed class TimeModule : BaseModuleInstaller<TimeModule>
    {
        public TimeModule(EcsSystems systems, PausableSystemsSolver pausableSystemsSolver) : base(systems,
            pausableSystemsSolver)
        {
        }
    }
}