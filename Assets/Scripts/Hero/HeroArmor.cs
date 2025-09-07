using Screpts.Services.PersistenProfress;
using Scripts.Data;
using UnityEngine;

namespace Screpts.Hero
{
    public class HeroArmor : MonoBehaviour ,ISavedProgress
    {
        private State _state;
        private float _armor;
        public float Armor
        {
            get => _armor;
            set => _armor = value;
        }

        public void LoadProgress(PlayerProgress playerProgress)
        {
            _state = playerProgress.HeroState;
        }

        public void UpdateProgress(PlayerProgress playerProgress)
        {
            playerProgress.HeroState.Armor = Armor;
        }
    }
}