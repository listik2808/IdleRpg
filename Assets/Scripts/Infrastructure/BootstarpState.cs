using Screpts.Services;
using UnityEngine;

namespace Scripts.Infrastructure
{
    public class BootstarpState : IState
    {
        private const string Initial = "Initial";
        private readonly GameStateMashine _gameStateMashine;
        private readonly SceneLoader _sceneLoader;

        public BootstarpState(GameStateMashine gameStateMashine, SceneLoader sceneLoader)
        {
            _gameStateMashine = gameStateMashine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            RegisterServices();
            _sceneLoader.Load("Initial", onLoaded: EnterLoadLevel);
        }

        public void Exit()
        {
        }

        private void EnterLoadLevel() => 
            _gameStateMashine.Enter<LoadLevelState,string>("Main");

        private void RegisterServices()
        {
            RegisterInputService();
        }

        private void RegisterInputService()
        {
            if (Application.isEditor)
            {
                Game.InputServices = new StandaloneInputService();
                Game.SetDevice(false);

            }
            else
            {
                Game.InputServices = new MobileInputService();
                Game.SetDevice(true);
            }
        }
    }
}