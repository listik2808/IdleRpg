using Scripts.StaticData;

namespace Scripts.Infrastructure.Services
{
    public interface IStaticDataService : IService
    {
        MonsterStaticData ForMonster(MonsterTypeId monsterTypeId);
        void LoadMonsters();
    }
}