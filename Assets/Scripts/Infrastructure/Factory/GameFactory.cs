using Scripts.Infrastructure.AssetManagment;
using Scripts.StaticData;
using UnityEngine;

namespace Scripts.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assetProvider;

        public GameFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public GameObject CreateHero(GameObject initialPoint)
        {
            return _assetProvider.Instantiate(AssetPath.Hero, initialPoint.transform.position);
        }

        public void CreateJoystick()
        {
            _assetProvider.Instantiate(AssetPath.Joystick);
        }

        public GameObject CreateMonster(MonsterTypeId monsterTypeId, Transform transform)
        {
            
        }
    }
}