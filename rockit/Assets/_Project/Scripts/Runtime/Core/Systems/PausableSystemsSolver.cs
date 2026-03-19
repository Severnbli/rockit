using Leopotam.EcsProto.ConditionalSystems;

namespace _Project.Scripts.Runtime.Core.Systems
{
    public class PausableSystemsSolver : IConditionalSystemSolver
    {
        public bool Paused { get; private set; } = false;
        
        public bool Solve() => !Paused;
        
        public void Pause() => Paused = true;
        public void Resume() => Paused = false;
    }
}