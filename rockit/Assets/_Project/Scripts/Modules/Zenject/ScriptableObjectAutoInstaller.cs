using Zenject;

namespace _Project.Scripts.Modules.Zenject
{
    public class ScriptableObjectAutoInstaller<T> : ScriptableObjectInstaller 
        where T : ScriptableObjectAutoInstaller<T>
    {
        public sealed override void InstallBindings()
        {
            RegisterBindings();
            Container.Bind<T>().FromInstance((T) this).AsSingle();
        }
        
        protected virtual void RegisterBindings() {}
    }
}