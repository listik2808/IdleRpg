using Scripts.Infrastructure.Services;
using Scripts.Infrastructure.State;

namespace Scripts.Infrastructure
{
    public class Game
    {
        public GameStateMashine StateMashine;
        private static bool _isMobile = false;

        public static bool IsMobile => _isMobile;
        
        public Game(ICoroutineRunner coroutineRunner)
        {
            StateMashine = new GameStateMashine(new SceneLoader(coroutineRunner), AllServices.Container);
        }

        public static void SetDevice(bool value)
        {
            _isMobile = value;
        }
    }
}