using System;
using System.Collections.Generic;
using _Project.Scripts.Runtime.Core.Bootstrap.States.Project;
using _Project.Scripts.Runtime.Core.Bootstrap.States.Scenes;
using _Project.Scripts.Runtime.Shared.Extensions.Shared;
using _Project.Scripts.Runtime.Shared.Utils.Shared;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Bootstrap.States
{
    public class StateMachine : IStateMachine
    {
        protected readonly Dictionary<Type, IState> ProjectStates = new();
        protected readonly Dictionary<Type, IState> SceneStates = new();
        protected readonly HashSet<IState> ActiveStates = new();
        
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
            if (!TryFindState<T>(out var state)) return;
            
            await ChangeState(state);
        }

        public async UniTask ChangeState(IState state)
        {
            await LeaveActiveStates();
            await EnterState(state);
        }

        private async UniTask LeaveActiveStates()
        {
            var leaveTasks = GetActiveStatesLeaveTasks();
            ActiveStates.Clear();
            await UniTask.WhenAll(leaveTasks);
        }

        private async UniTask EnterState(IState state)
        {
            if (state is null) return;
            
            ActiveStates.Add(state);
            await state.OnEnter();
        }

        private UniTask[] GetActiveStatesLeaveTasks()
        {
            var tasks = new UniTask[ActiveStates.Count];

            var i = 0;
            foreach (var state in ActiveStates)
            {
                tasks[i++] = state.OnLeave();
            }
            
            return tasks;
        }

        public async UniTask OpenModalState<T>() where T : IState
        {
            await UniTask.CompletedTask;
        }

        public async UniTask CloseModalState<T>() where T : IState
        {
            await UniTask.CompletedTask;
        }

        private bool TryFindState<T>(out IState state) where T : IState
        {
            if (SceneStates.TryGetByAssignableType(out state) || ProjectStates.TryGetByAssignableType(out state))
            {
                return true;
            }
            
            LogUtils.LogError($"Did not find state with type {typeof(T)}");
            return false;
        }

        public void BootstrapSceneStates(params ISceneState[] states)
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
            Inited = true;
        }
    }
}