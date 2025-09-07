using Screpts.Hero;
using Screpts.Services.PersistenProfress;
using Scripts.Infrastructure.AssetManagment;
using Scripts.Infrastructure.Services;
using Scripts.Infrastructure.Services.PersistenProgress;
using Scripts.Logic;
using Scripts.StaticData;
using Scripts.UI;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IStaticDataService _staticDataService;
        private readonly IHeroStaticDataService _heroStaticDataService;
        private readonly IPersistenProgressServices _persistenProgressServices;

        public List<ISavedProgressReader>ProgressReaders { get; } = new List<ISavedProgressReader>();
        public List<ISavedProgress> ProgressWriters{ get; } = new List<ISavedProgress>();

        public GameFactory(IAssetProvider assetProvider,IStaticDataService staticDataService, IHeroStaticDataService heroStaticDataService,IPersistenProgressServices progressServices)
        {
            _assetProvider = assetProvider;
            _staticDataService = staticDataService;
            _heroStaticDataService = heroStaticDataService;
            _persistenProgressServices = progressServices;
        }

        public GameObject CreateHero(GameObject initialPoint)
        {
            GameObject hero = _assetProvider.Instantiate(AssetPath.Hero, initialPoint.transform.position);
            HeroStaticData heroStaticData = _heroStaticDataService.GetData();
            IHeath health = hero.GetComponent<IHeath>();
            health.Current = heroStaticData.Hp;
            health.Max = heroStaticData.Hp;

            hero.GetComponent<ActorUI>().Construct(health);
            HeroArmor heroArmor = hero.GetComponent<HeroArmor>();
            heroArmor.Armor = heroStaticData.Armor;
            Attack heroAttack = hero.GetComponent<Attack>();
            heroAttack.Damage = heroStaticData.Damage;
            RegisterProgressWatchers(hero);
            return hero;
        }

        private void RegisterProgressWatchers(GameObject gameObject)
        {
            foreach (ISavedProgressReader progressReader in gameObject.GetComponentsInChildren<ISavedProgressReader>())
            {
                Register(progressReader);
            }
        }

        public GameObject CreateHud()
        {
            return _assetProvider.Instantiate(AssetPath.HUD);
        }

        public GameObject CreateMonster(MonsterTypeId TypeId, Transform transform)
        {
            MonsterStaticData monsterData = _staticDataService.ForMonster(TypeId);
            GameObject monster = Object.Instantiate(monsterData.Prefab,transform.parent.position,Quaternion.identity,transform.parent);

            //Создать класс здоровья передать ему здоровья и так далее (9 папка 6 видео)

            return monster;
        }

        public void Cleanup()
        {
            ProgressReaders.Clear();
            ProgressWriters.Clear();
        }

        private void Register(ISavedProgressReader progressReader) 
        {
            if (progressReader is ISavedProgress progressWriter)
            {
                ProgressWriters.Add(progressWriter);
            }
            ProgressReaders.Add(progressReader);
        }
    }
}