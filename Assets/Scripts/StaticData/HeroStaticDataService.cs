using Scripts.Infrastructure.Services;
using UnityEngine;

namespace Scripts.StaticData
{
    public class HeroStaticDataService : IHeroStaticDataService
    {
        private HeroStaticData _heroStaticData;
        public void LoadHeroStaticData(HeroStaticData heroStaticData)
        {
            _heroStaticData = heroStaticData;
           
        }

        public HeroStaticData GetData()
        {
            return _heroStaticData;
        }
    }
}
