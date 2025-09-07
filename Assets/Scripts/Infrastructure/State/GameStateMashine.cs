using Scripts.Infrastructure.Factory;
using Scripts.Infrastructure.SaveLoad;
using Scripts.Infrastructure.Services;
using Scripts.Infrastructure.Services.PersistenProgress;
using Scripts.StaticData;
using System;
using System.Collections.Generic;

namespace Scripts.Infrastructure.State
{
    public class GameStateMashine : IGameStateMashine
    {
        private readonly Dictionary<Type, IExitebleState> _state;
        private IExitebleState _activeState;
        private HeroStaticData _heroStaticData;
        public GameStateMashine(SceneLoader sceneLoader, AllServices services,HeroStaticData heroStatic)
        {
            _state = new Dictionary<Type, IExitebleState>
            {
                [typeof(BootstarpState)] = new BootstarpState(this, sceneLoader, services,heroStatic),
                [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader, services.Single<IGameFactory>(),services.Single<IPersistenProgressServices>()),
                [typeof(LoadProgressState)] = new LoadProgressState(this,services.Single<IPersistenProgressServices>(),services.Single<ISaveLoadService>()),
                [typeof(LoadLevelBattleState)] = new LoadLevelBattleState(this,sceneLoader, services.Single<IGameFactory>()),
                [typeof(GameLoopState)] = new GameLoopState(this),
            };
        }

        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayLoad>(TPayLoad payLoad) where TState : class, IPayLoadedState<TPayLoad>
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