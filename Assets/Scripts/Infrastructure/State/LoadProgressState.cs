using Scripts.Data;
using Scripts.Infrastructure.SaveLoad;
using Scripts.Infrastructure.Services.PersistenProgress;
using System;

namespace Scripts.Infrastructure.State
{
    public class LoadProgressState : IState
    {
        private readonly GameStateMashine _stateMashine;
        private readonly IPersistenProgressServices _persistenProgress;
        private readonly ISaveLoadService _saveLoadServise;

        public LoadProgressState(GameStateMashine stateMashine,IPersistenProgressServices persistenProgress,ISaveLoadService saveLoadService) 
        {
            _stateMashine = stateMashine;
            _persistenProgress = persistenProgress;
            _saveLoadServise = saveLoadService;
        }

        public void Enter()
        {
            LoadProgressOrInitNew();
            _stateMashine.Enter<LoadLevelState, string>(_persistenProgress.Progress.WorldData.PositionOnLevel.Level);
        }

        public void Exit()
        {
            
        }

        private void LoadProgressOrInitNew()
        {
            _persistenProgress.Progress = _saveLoadServise.LoadProgress() ?? NewProgress();
        }

        private PlayerProgress NewProgress() =>
            new PlayerProgress(initialLevel: "Main");
    }
}