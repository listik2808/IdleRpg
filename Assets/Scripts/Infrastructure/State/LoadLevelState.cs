using Screpts.Hero;
using Screpts.Services.PersistenProfress;
using Scripts.CameraLogic;
using Scripts.Infrastructure.AssetManagment;
using Scripts.Infrastructure.Factory;
using Scripts.Infrastructure.Services.PersistenProgress;
using System;
using UnityEngine;

namespace Scripts.Infrastructure.State
{
    public class LoadLevelState : IPayLoadedState<string>
    {
        private readonly GameStateMashine _gameStateMashine;
        private readonly SceneLoader _sceneLoader;
        private readonly IGameFactory _gameFactory;
        private readonly IPersistenProgressServices _persistenProgressServices;

        public LoadLevelState(GameStateMashine gameStateMashine, SceneLoader sceneLoader, IGameFactory gameFactory,IPersistenProgressServices persistenProgressServices)
        {
            _gameStateMashine = gameStateMashine;
            _sceneLoader = sceneLoader;
            _gameFactory = gameFactory;
            _persistenProgressServices = persistenProgressServices;
        }

        public void Enter(string sceneName)
        {
            _gameFactory.Cleanup();
            _sceneLoader.Load(sceneName,OnLoaded);
        }

        public void Exit()
        {
        }

        private void OnLoaded()
        {
            InitGameWorld();
            InformsProgressReaders();

            _gameStateMashine.Enter<GameLoopState>();
        }

        private void InformsProgressReaders()
        {
            foreach (ISavedProgressReader progressReader in _gameFactory.ProgressReaders)
            {
                progressReader.LoadProgress(_persistenProgressServices.Progress);
            }
        }

        private void InitGameWorld()
        {
            GameObject hero = _gameFactory.CreateHero(GameObject.FindWithTag(AssetPath.InitialPoint));
            GameObject hud = _gameFactory.CreateHud();
            Player player = hero.GetComponent<Player>();
            FastSlot fastSlot = hud.GetComponentInChildren<FastSlot>();
            RightHandSlot rightHandSlot = player.GetComponent<RightHandSlot>();
            player.SetSlots(fastSlot,rightHandSlot);
            CameraFollow(hero);
        }

        private static void CameraFollow(GameObject hero)
        {
            Camera.main.GetComponent<CameraFollow>().Follow(hero);
        }
    }
}