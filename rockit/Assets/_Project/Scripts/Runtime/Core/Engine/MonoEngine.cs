using System.Collections.Generic;
using _Project.Scripts.Runtime.Core.Systems;
using Leopotam.EcsProto;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Runtime.Core.Engine
{
    public class MonoEngine : MonoBehaviour, IEngine
    {
        private ProtoWorld _world;
        private ProtoSystems _runSystems;
        private ProtoSystems _fixedRunSystems;

        [Inject]
        public void Construct(ProtoWorld world, List<IRunSystems> runSystems, List<IFixedRunSystems> fixedRunSystems)
        {
            _world = world;

            _runSystems = new ProtoSystems(_world);
            foreach (var runSystem in runSystems)
            {
                _runSystems.AddSystem(runSystem);
            }
            
            _fixedRunSystems = new ProtoSystems(_world);
            foreach (var fixedRunSystem in fixedRunSystems)
            {
                _fixedRunSystems.AddSystem(fixedRunSystem);
            }
        }

        protected virtual void Start()
        {
            Init();
        }
        
        public void Init()
        {
            _runSystems?.Init();
        }

        protected virtual void Update()
        {
            Run();
        }

        public void Run()
        {
            _runSystems?.Run();
        }

        protected virtual void FixedUpdate()
        {
            FixedRun();
        }

        public void FixedRun()
        {
            _fixedRunSystems?.Run();
        }

        protected virtual void OnDestroy()
        {
            Destroy();
        }

        public void Destroy()
        {
            _runSystems?.Destroy();
            _runSystems = null;
            
            _fixedRunSystems?.Destroy();
            _fixedRunSystems = null;
        }
    }
}