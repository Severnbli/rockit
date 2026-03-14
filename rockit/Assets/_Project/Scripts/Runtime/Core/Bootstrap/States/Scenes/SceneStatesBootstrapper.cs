namespace _Project.Scripts.Runtime.Core.Bootstrap.States.Scenes
{
    public class SceneStatesBootstrapper
    {
        protected readonly IStateMachine StateMachine;
        
        public SceneStatesBootstrapper(IStateMachine stateMachine)
        {
            StateMachine = stateMachine;
            Bootstrap();
        }

        private void Bootstrap()
        {
            ;
        }
    }
}