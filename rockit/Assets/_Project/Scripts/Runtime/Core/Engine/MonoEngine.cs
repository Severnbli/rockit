using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Engine
{
    public class MonoEngine : MonoBehaviour, IEngine
    {
        protected virtual void Start()
        {
            Init();
        }
        
        public void Init()
        {
            ;
        }

        protected virtual void Update()
        {
            Run();
        }

        public void Run()
        {
            ;
        }

        protected virtual void FixedUpdate()
        {
            FixedRun();
        }

        public void FixedRun()
        {
            ;
        }

        protected virtual void OnDestroy()
        {
            Destroy();
        }

        public void Destroy()
        {
            ;
        }
    }
}