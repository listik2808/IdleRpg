using Scripts.Data;

namespace Scripts.Infrastructure.Services.PersistenProgress
{
    public interface IPersistenProgressServices : IService
    {
        PlayerProgress Progress { get; set; }
    }
}