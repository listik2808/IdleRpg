using Scripts.Data;

namespace Scripts.Infrastructure.Services.PersistenProgress
{
    public class PersistenProgressServices : IPersistenProgressServices
    {
        public PlayerProgress Progress { get; set; }
    }
}
