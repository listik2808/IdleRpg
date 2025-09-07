using Screpts.Hero;
using Scripts.Logic;
using UnityEngine;

namespace Scripts.UI
{
    public class ActorUI : MonoBehaviour
    {
        [SerializeField] private HpBar _hpBar;
        private IHeath _heroHealth;
        private void OnDestroy()
        {
            _heroHealth.HealthChanged -= UpdateHpBar;
        }

        public void Construct(IHeath heroHealth)
        {
            _heroHealth = heroHealth;
            _heroHealth.HealthChanged += UpdateHpBar;
        }

        private void UpdateHpBar()
        {
            _hpBar.SetValue(_heroHealth.Current,_heroHealth.Max);
        }
    }
}
