using System;
using System.Collections.Generic;
using _Project.Scripts.Runtime.Core.Bootstrap.States.Project;
using _Project.Scripts.Runtime.Core.Bootstrap.States.Scenes;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Bootstrap.States
{
    public class StateMachine : IStateMachine
    {
        protected IState ActiveState;
        protected readonly Dictionary<Type, IState> ProjectStates = new();
        protected readonly Dictionary<Type, IState> SceneStates = new();
        
        public bool Inited { get; private set; } = false;

        public StateMachine(List<IProjectState> states)
        {
            foreach (var state in states)
            {
                ProjectStates.Add(state.GetType(), state);
            }
        }
        
        public async UniTask ChangeState<T>() where T : IState
        {
            if (!SceneStates.TryGetValue(typeof(T), out var state) && !ProjectStates.TryGetValue(typeof(T), out state))
            {
#if DEBUG
                throw new Exception($"Did not find state with type {typeof(T)}");
#endif
                return;
            }
            
            await ChangeState(state);
        }

        public async UniTask ChangeState(IState state)
        {
            if (ActiveState is not null) await ActiveState.OnLeave();
            ActiveState = state;
            if (ActiveState is not null) await ActiveState.OnEnter();
        }

        public void SetupSceneStates(params IState[] states)
        {
            SceneStates.Clear();
            foreach (var state in states)
            {
                SceneStates.Add(state.GetType(), state);
            }

            if (Inited)
            {
                ChangeState<ISceneSetupState>().Forget();
                return;
            }
            
            ChangeState<IProjectSetupState>().Forget();
        }
    }
}