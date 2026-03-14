using System;
using System.Collections.Generic;
using _Project.Scripts.Runtime.Core.Bootstrap.StateMachine.Project;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Bootstrap.StateMachine
{
    public class ProjectStateMachine : IProjectStateMachine
    {
        protected IState ActiveState;
        protected readonly Dictionary<Type, IState> ProjectStates = new();
        protected readonly Dictionary<Type, IState> SceneStates = new();

        public ProjectStateMachine(List<IProjectState> states)
        {
            foreach (var state in states)
            {
                ProjectStates.Add(state.GetType(), state);
            }
        }
        
        public async UniTask ChangeState<T>() where T : IState
        {
            throw new System.NotImplementedException();
        }

        public async UniTask ChangeState(IState state)
        {
            if (ActiveState is not null) await ActiveState.OnLeave();
            ActiveState = state;
            if (ActiveState is not null) await ActiveState.OnEnter();
        }

        public void SetupSceneStates(params IState[] states)
        {
            throw new System.NotImplementedException();
        }
    }
}