namespace _Project.Scripts.Runtime.Core.Engine
{
    public interface IEngine
    {
        void Init();
        void Run();
        void FixedRun();
        void Destroy();
    }
}