using Screpts.Services;
using Screpts.Services.Input;
using Scripts.Infrastructure.AssetManagment;
using Scripts.Infrastructure.Factory;
using Scripts.Infrastructure.Services;
using Scripts.StaticData;
using UnityEngine;

namespace Scripts.Infrastructure.State
{
    public class BootstarpState : IState
    {
        private readonly GameStateMashine _gameStateMashine;
        private readonly SceneLoader _sceneLoader;
        private readonly AllServices _services;

        public BootstarpState(GameStateMashine gameStateMashine, SceneLoader sceneLoader,AllServices services)
        {
            _gameStateMashine = gameStateMashine;
            _sceneLoader = sceneLoader;
            _services = services;
            RegisterServices();
        }

        public void Enter()
        {
            _sceneLoader.Load(AssetPath.Initial, onLoaded: EnterLoadLevel);
        }

        public void Exit()
        {
        }

        private void EnterLoadLevel() => 
            _gameStateMashine.Enter<LoadLevelState,string>(AssetPath.MainScena);

        private void RegisterServices()
        {
            _services.RegisterSingle<IInputServices>(InputService());
            _services.RegisterSingle<IAssetProvider>(new AssetProvider());
            _services.RegisterSingle<IGameFactory>(new GameFactory(_services.Single<IAssetProvider>()));
            _services.RegisterSingle<IGameStateMashine>(_gameStateMashine);
            RegisterStaticData();
        }

        private void RegisterStaticData()
        {
            IStaticDataService staticData = new StaticDataService();
            staticData.LoadMonsters();
            _services.RegisterSingle(staticData);
        }

        private static IInputServices InputService()
        {
            if (Application.isEditor)
            {
                Game.SetDevice(false);
                return new StandaloneInputService();
            }
            else
            {
                Game.SetDevice(true);
                return new MobileInputService();
            }
        }
    }
}