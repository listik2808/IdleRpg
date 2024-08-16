using Scripts.Infrastructure.Services;
using Scripts.StaticData;
using UnityEngine;

namespace Scripts.Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        GameObject CreateHero(GameObject initialPoint);
        void CreateJoystick();
        GameObject CreateMonster(MonsterTypeId monsterTypeId, Transform parent);
    }
}