using Screpts.Services;
using Screpts.Services.Input;
using Scripts.Infrastructure.AssetManagment;
using Scripts.Infrastructure.Factory;
using Scripts.Infrastructure.SaveLoad;
using Scripts.Infrastructure.Services;
using Scripts.Infrastructure.Services.PersistenProgress;
using Scripts.StaticData;
using UnityEngine;

namespace Scripts.Infrastructure.State
{
    public class BootstarpState : IState
    {
        private readonly GameStateMashine _gameStateMashine;
        private readonly SceneLoader _sceneLoader;
        private readonly AllServices _services;
        private HeroStaticData _heroStaticData;
        public BootstarpState(GameStateMashine gameStateMashine, SceneLoader sceneLoader,AllServices services, HeroStaticData heroStaticData)
        {
            _gameStateMashine = gameStateMashine;
            _sceneLoader = sceneLoader;
            _services = services;
            _heroStaticData = heroStaticData;
            RegisterServices(_heroStaticData);
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

        private void RegisterServices(HeroStaticData heroStaticData)
        {
            RegisterStaticData(heroStaticData);
            _services.RegisterSingle<IInputServices>(InputService());
            _services.RegisterSingle<IAssetProvider>(new AssetProvider());
            _services.RegisterSingle<IPersistenProgressServices>(new PersistenProgressServices());
            _services.RegisterSingle<IGameFactory>(new GameFactory(_services.Single<IAssetProvider>()
                ,_services.Single<IStaticDataService>(),_services.Single<IHeroStaticDataService>(),_services.Single<IPersistenProgressServices>()));
            _services.RegisterSingle<IGameStateMashine>(_gameStateMashine);
            _services.RegisterSingle<ISaveLoadService>(new SaveLoadService(_services.Single<IGameFactory>(),_services.Single<IPersistenProgressServices>()));
        }

        private void RegisterStaticData(HeroStaticData heroStaticData)
        {
            IStaticDataService staticData = new StaticDataService();
            staticData.LoadMonsters();
            _services.RegisterSingle(staticData);

            IHeroStaticDataService heroStaticDataService = new HeroStaticDataService();
            heroStaticDataService.LoadHeroStaticData(heroStaticData);
            _services.RegisterSingle(heroStaticDataService);
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