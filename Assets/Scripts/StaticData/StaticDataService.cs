using Scripts.Infrastructure.Services;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Scripts.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<MonsterTypeId, MonsterStaticData> _monster;

        public void LoadMonsters()
        {
            _monster = Resources.LoadAll<MonsterStaticData>("StaticData/Monster").ToDictionary(x => x.monsterTypeId, x => x);
        }

        public MonsterStaticData ForMonster(MonsterTypeId monsterTypeId) =>
            _monster.TryGetValue(monsterTypeId, out MonsterStaticData staticData) ? staticData : null;
    }
}
