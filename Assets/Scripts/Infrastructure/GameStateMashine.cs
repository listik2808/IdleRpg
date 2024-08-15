using System;
using System.Collections.Generic;

namespace Scripts.Infrastructure
{
    public class GameStateMashine
    {
        private readonly Dictionary<Type, IExitebleState> _state;
        private IExitebleState _activeState;

        public GameStateMashine(SceneLoader sceneLoader) 
        {
            _state = new Dictionary<Type, IExitebleState>
            {
                [typeof(BootstarpState)] = new BootstarpState(this,sceneLoader),
                [typeof(LoadLevelState)] = new LoadLevelState(this,sceneLoader),
            };
        }

        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState,TPayLoad>(TPayLoad payLoad) where TState : class, IPayLoadedState<TPayLoad>
        {
            TState state = ChangeState<TState>();
            state.Enter(payLoad);
        }

        private TState ChangeState<TState>() where TState : class, IExitebleState
        {
            _activeState?.Exit();

            TState state = GetState<TState>();
            _activeState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class, IExitebleState =>
            _state[typeof(TState)] as TState;
    }
}