using Scripts.Infrastructure.AssetManagment;
using Scripts.Infrastructure.Factory;
using UnityEngine;

namespace Scripts.Infrastructure.State
{
    public class LoadLevelBattleState : IPayLoadedState<string>
    {

        private readonly GameStateMashine _gameStateMashine;
        private readonly SceneLoader _sceneLoader;
        private readonly IGameFactory _gameFactory;

        public LoadLevelBattleState(GameStateMashine gameStateMashine, SceneLoader sceneLoader, IGameFactory gameFactory)
        {
            _gameStateMashine = gameStateMashine;
            _sceneLoader = sceneLoader;
            _gameFactory = gameFactory;
        }

        public void Enter(string sceneName)
        {
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit()
        {
            
        }

        private void OnLoaded()
        {
            GameObject hero = _gameFactory.CreateHero(GameObject.FindWithTag(AssetPath.InitialPoint));
        }
    }
}