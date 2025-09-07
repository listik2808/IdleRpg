using Scripts.Data;
using Scripts.Infrastructure.Services;
using Scripts.Infrastructure.State;

namespace Scripts.Infrastructure.SaveLoad
{
    public interface ISaveLoadService :IService
    {
        void SaveProgress();
        PlayerProgress LoadProgress();
    }
}