using Leopotam.EcsProto;
using Leopotam.EcsProto.ConditionalSystems;

namespace _Project.Scripts.Runtime.Core.Systems
{
    public class PausableSystems : ConditionalSystem
    {
        public PausableSystems(PausableSystemsSolver solver, params IProtoSystem[] nestedSystems) : base(solver, true, nestedSystems)
        {
        }
    }
}