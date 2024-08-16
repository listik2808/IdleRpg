using Screpts.Hero;
using Scripts.ScreenPortal;
using UnityEngine;

namespace Scripts.PortalTeleport
{
    public class Portal : MonoBehaviour
    {
        [SerializeField] private PanelTeleportal _panelTeleportLevel1;
        private HeroMove _heroMove;

        private void OnEnable()
        {
            _panelTeleportLevel1.ActivateMoveHero += TakeBackControl;
        }

        private void OnDisable()
        {
            _panelTeleportLevel1.ActivateMoveHero -= TakeBackControl;
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out HeroMove heroMove))
            {
                _panelTeleportLevel1.gameObject.SetActive(true);
                heroMove.enabled = false;
                _heroMove = heroMove;
            }
            
        }

        private void TakeBackControl()
        {
            _heroMove.enabled = true;
        }
    }
}