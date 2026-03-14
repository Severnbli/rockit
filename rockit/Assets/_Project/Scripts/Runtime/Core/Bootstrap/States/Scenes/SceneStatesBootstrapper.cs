namespace _Project.Scripts.Runtime.Core.Bootstrap.States.Scenes
{
    public class SceneStatesBootstrapper
    {
        protected readonly IStateMachine StateMachine;
        protected readonly ISceneState[] SceneStates;
        
        public SceneStatesBootstrapper(IStateMachine stateMachine, ISceneState[] sceneStates)
        {
            StateMachine = stateMachine;
            SceneStates = sceneStates;
            Bootstrap();
        }

        private void Bootstrap()
        {
            StateMachine.BootstrapSceneStates(SceneStates);
        }
    }
}