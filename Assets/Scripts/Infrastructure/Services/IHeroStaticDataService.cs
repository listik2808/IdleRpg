using Scripts.StaticData;

namespace Scripts.Infrastructure.Services
{
    public interface IHeroStaticDataService : IService
    {
        HeroStaticData GetData();
        void LoadHeroStaticData(HeroStaticData heroStaticData);
    }
}