using Scripts.Infrastructure.Services;
using Scripts.Infrastructure.State;
using Scripts.StaticData;

namespace Scripts.Infrastructure
{
    public class Game
    {
        public GameStateMashine StateMashine;
        private static bool _isMobile = false;

        public static bool IsMobile => _isMobile;
        
        public Game(ICoroutineRunner coroutineRunner,HeroStaticData heroStatic)
        {
            StateMashine = new GameStateMashine(new SceneLoader(coroutineRunner), AllServices.Container, heroStatic);
        }

        public static void SetDevice(bool value)
        {
            _isMobile = value;
        }
    }
}