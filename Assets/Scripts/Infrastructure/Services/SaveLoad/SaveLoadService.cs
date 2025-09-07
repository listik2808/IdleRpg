using Screpts.Services.PersistenProfress;
using Scripts.Data;
using Scripts.Infrastructure.Factory;
using Scripts.Infrastructure.Services.PersistenProgress;
using UnityEngine;

namespace Scripts.Infrastructure.SaveLoad
{
    public class SaveLoadService : ISaveLoadService
    {
        private readonly IPersistenProgressServices _progressServices;
        private readonly IGameFactory _gameFactory;
        private string _json;

        public SaveLoadService(IGameFactory gameFactory,IPersistenProgressServices progressServices)
        {
            _gameFactory = gameFactory;
            _progressServices = progressServices;
        }

        public void SaveProgress()
        {
            foreach (ISavedProgress progressWriter in _gameFactory.ProgressWriters)
                progressWriter.UpdateProgress(_progressServices.Progress);

            _json = JsonUtility.ToJson(_progressServices.Progress);
        }

        public PlayerProgress LoadProgress()
        {
            _progressServices.Progress = JsonUtility.FromJson<PlayerProgress>(_json);
            return _progressServices.Progress;
        }
    }
}