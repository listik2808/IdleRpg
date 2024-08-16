using Scripts.CameraLogic;
using Scripts.Infrastructure.AssetManagment;
using Scripts.Infrastructure.Factory;
using UnityEngine;

namespace Scripts.Infrastructure.State
{
    public class LoadLevelState : IPayLoadedState<string>
    {
        private readonly GameStateMashine _gameStateMashine;
        private readonly SceneLoader _sceneLoader;
        private readonly IGameFactory _gameFactory;

        public LoadLevelState(GameStateMashine gameStateMashine, SceneLoader sceneLoader, IGameFactory gameFactory)
        {
            _gameStateMashine = gameStateMashine;
            _sceneLoader = sceneLoader;
            _gameFactory = gameFactory;
        }

        public void Enter(string sceneName)
        {
            _sceneLoader.Load(sceneName,OnLoaded);
        }

        public void Exit()
        {
        }

        private void OnLoaded()
        {
            GameObject hero = _gameFactory.CreateHero(GameObject.FindWithTag(AssetPath.InitialPoint));
            _gameFactory.CreateJoystick();

            CameraFollow(hero);
        }

        private static void CameraFollow(GameObject hero)
        {
            Camera.main.GetComponent<CameraFollow>().Follow(hero);
        }
    }
}