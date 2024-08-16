using Scripts.Infrastructure.Factory;
using Scripts.Infrastructure.Services;
using Scripts.StaticData;
using UnityEngine;

namespace Scripts.Logic
{
    public class EnemySpawner :MonoBehaviour
    {
        public MonsterTypeId MonsterTypeId;
        private IGameFactory _gameFactory;

        private void Awake()
        {
            _gameFactory = AllServices.Container.Single<IGameFactory>();
        }

        private void Spawn()
        {
            GameObject monster = _gameFactory.CreateMonster(MonsterTypeId, transform);
        }
    }
}
