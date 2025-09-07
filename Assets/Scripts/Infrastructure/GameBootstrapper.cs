using Scripts.Infrastructure.State;
using Scripts.StaticData;
using UnityEngine;

namespace Scripts.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour , ICoroutineRunner
    {
        [SerializeField] private HeroStaticData staticData;
        private Game _game;

        private void Awake()
        {
            _game = new Game(this,staticData);
            _game.StateMashine.Enter<BootstarpState>();
            DontDestroyOnLoad(this);
        }
    }
}