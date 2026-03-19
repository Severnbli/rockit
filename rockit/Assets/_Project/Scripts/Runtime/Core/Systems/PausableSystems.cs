using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Core.Systems
{
    public class PausableSystems : ConditionalSystems
    {
        public PausableSystems(PausableSystemsSolver solver, params IProtoSystem[] nestedSystems) : base(solver, true, nestedSystems)
        {
        }
    }
}