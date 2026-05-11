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
        private bool _locked = false;
        
        protected readonly Dictionary<Type, IState> ProjectStates = new();
        protected readonly Dictionary<Type, IState> SceneStates = new();
        protected readonly HashSet<IState> ModalStates = new();
        protected IState ActiveState;
        
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
            if (_locked) return;
            
            if (!TryFindState<T>(out var state)) return;
            
            await ChangeState(state);
        }

        public async UniTask ChangeState(IState state)
        {
            if (_locked) return;
            
            LogUtils.Log($"Switching from {ActiveState?.GetType().Name} to {state.GetType().Name}");
            
            await LeaveActiveState();
            await EnterActiveState(state);
        }

        private async UniTask LeaveActiveState()
        {
            _locked = true;
            var tasks = new UniTask[ModalStates.Count + 1];

            var i = 0;
            foreach (var state in ModalStates)
            {
                tasks[i++] = state.OnLeave(this);
            }

            tasks[i] = ActiveState?.OnLeave(this) ?? UniTask.NextFrame();
            
            ModalStates.Clear();
            ActiveState = null;
            
            await UniTask.WhenAll(tasks);
            _locked = false;
        }

        private async UniTask EnterActiveState(IState state)
        {
            if (state is null) return;
            
            ActiveState = state;
            await ActiveState.OnEnter(this);
        }

        public async UniTask EnterModalState<T>() where T : IState
        {
            if (!TryFindState<T>(out var state)) return;
            
            await EnterModalState(state);
        }

        public async UniTask EnterModalState(IState state)
        {
            if (!ModalStates.Add(state)) return;
            await state.OnEnter(this);
        }

        public async UniTask LeaveModalState<T>() where T : IState
        {
            if (!TryFindState<T>(out var state)) return;
            
            await LeaveModalState(state);
        }

        public async UniTask LeaveModalState(IState state)
        {
            if (!ModalStates.Remove(state)) return;
            await state.OnLeave(this);
        }

        private bool TryFindState<T>(out T state) where T : IState
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

            Inited = true;
            ChangeState<IProjectSetupState>().Forget();
        }
    }
}