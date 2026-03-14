using Leopotam.EcsProto.ConditionalSystems;

namespace _Project.Scripts.Runtime.Core.Systems
{
    public class PausableSystemsSolver : IConditionalSystemSolver
    {
        public bool Paused { get; set; } = false;
        
        public bool Solve() => !Paused;
    }
}