using System;
using Leopotam.EcsProto;
using Leopotam.EcsProto.ConditionalSystems;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Core.Systems
{
    public class ConditionalSystems : IProtoInitSystem, IProtoRunSystem, IProtoFixedRunSystem, IProtoDestroySystem, IProtoNestedSystems {
        readonly IConditionalSystemSolver _solver;
        readonly bool _autoInject;
        IProtoSystem[] _nestedSystems;
        EcsSystems _protoSystems;

        public ConditionalSystems (IConditionalSystemSolver solver, bool autoInject, params IProtoSystem[] nestedSystems) {
#if DEBUG
            if (solver == null) { throw new Exception ($"solver не может быть пустым"); }
            if (nestedSystems == null || nestedSystems.Length == 0) { throw new Exception ($"список систем не может быть пустым"); }
#endif
            _solver = solver;
            _autoInject = autoInject;
            _nestedSystems = nestedSystems;
        }

        public void Init (IProtoSystems systems) {
            _protoSystems = new (systems.World ());
            foreach (var kv in systems.NamedWorlds ()) {
                _protoSystems.AddWorld (kv.Value, kv.Key);
            }
            foreach (var kv in systems.Services ()) {
                _protoSystems.AddService (kv.Value, kv.Key);
            }
            var handler = _protoSystems
                .Services ()
                .TryGetValue (typeof (AutoInjectModule.Handler), out var handlerRaw)
                ? (AutoInjectModule.Handler) handlerRaw
                : null;
            AutoInjectModule.Inject (_solver, _protoSystems, handler);
            foreach (var s in _nestedSystems) {
                _protoSystems.AddSystem (s);
                if (_autoInject) {
                    AutoInjectModule.Inject (s, _protoSystems, handler);
                }
            }
            _nestedSystems = default;
            _protoSystems.Init ();
        }

        public void Run () {
            if (_solver.Solve ()) {
                _protoSystems.Run ();
            }
        }
        
        public void FixedRun()
        {
            if (_solver.Solve ()) {
                _protoSystems.FixedRun();
            }
        }

        public void Destroy () => _protoSystems.Destroy ();
        public Slice<IProtoSystem> Systems () => _protoSystems.Systems ();
    }
}