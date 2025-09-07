using Screpts.Services.PersistenProfress;
using Scripts.Infrastructure.Services;
using Scripts.StaticData;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        List<ISavedProgressReader> ProgressReaders { get; }
        List<ISavedProgress> ProgressWriters { get; }

        void Cleanup();
        GameObject CreateHero(GameObject initialPoint);
        GameObject CreateHud();
        GameObject CreateMonster(MonsterTypeId monsterTypeId, Transform parent);
    }
}