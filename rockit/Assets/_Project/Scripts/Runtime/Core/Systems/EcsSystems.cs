using System;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Core.Systems
{
    public class EcsSystems : ProtoSystems
    {
        protected Slice<IProtoFixedRunSystem> _fixedRunsystems;
        
        public EcsSystems(ProtoWorld defaultWorld) : base(defaultWorld)
        {
        }

        public override void Init()
        {
#if DEBUG
            if (IsInited()) { throw new Exception ("не могу инициализировать системы повторно"); }
#endif
            Array.Sort (_deferredSystemsOrder.Data(), 0, _deferredSystemsOrder.Len ());
            _allSystems = new (_systemsCount);
            _runSystems = new (_systemsCount);
            _fixedRunsystems = new (_systemsCount);
            foreach (var weight in _deferredSystemsOrder) {
                foreach (var sys in _deferredSystems[weight]) {
                    _allSystems.Add(sys);
                    if (sys is IProtoRunSystem runSys) {
                        _runSystems.Add(runSys);
                    }

                    if (sys is IProtoFixedRunSystem fixedRunSys)
                    {
                        _fixedRunsystems.Add(fixedRunSys);
                    }
                }
            }
            for (int i = 0, iMax = _allSystems.Len(); i < iMax; i++) {
                if (_allSystems.Get(i) is IProtoInitSystem iSystem) {
                    iSystem.Init(this);
                }
            }
            _inited = true;
        }

        public virtual void FixedRun()
        {
#if DEBUG
            if (!IsInited()) { throw new Exception ("системы не инициализированы"); }
#endif
            for (int i = 0, iMax = _fixedRunsystems.Len(); i < iMax; i++) {
                _fixedRunsystems.Get(i).FixedRun();
            }
        }
    }
}