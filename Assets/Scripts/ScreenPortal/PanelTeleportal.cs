using Scripts.Infrastructure.AssetManagment;
using Scripts.Infrastructure.Services;
using Scripts.Infrastructure.State;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.ScreenPortal
{
    public class PanelTeleportal : MonoBehaviour
    {
        [SerializeField] private Button _buttonYes;
        [SerializeField] private Button _buttonNo;
        private IGameStateMashine _gameStateMashine;

        public event Action ActivateMoveHero;

        private void OnEnable()
        {
            _buttonYes.onClick.AddListener(Loadlocation);
            _buttonNo.onClick.AddListener(ClosePanelTeleport);
        }

        private void OnDisable()
        {
            _buttonYes.onClick.RemoveListener(Loadlocation);
            _buttonNo.onClick.RemoveListener(ClosePanelTeleport);
        }

        private void Start()
        {
            _gameStateMashine = AllServices.Container.Single<IGameStateMashine>();
        }

        private void Loadlocation()
        {
            _gameStateMashine.Enter<LoadLevelBattleState,string>(AssetPath.SceneBattleLevel1);
        }

        private void ClosePanelTeleport()
        {
            ActivateMoveHero?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
