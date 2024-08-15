using Screpts.Services;

namespace Scripts.Infrastructure
{
    public class Game
    {
        public static IInputServices InputServices;
        public GameStateMashine StateMashine;
        private static bool _isMobile = false;

        public static bool IsMobile => _isMobile;
        
        public Game(ICoroutineRunner coroutineRunner)
        {
            StateMashine = new GameStateMashine(new SceneLoader(coroutineRunner));
        }

        public static void SetDevice(bool value)
        {
            _isMobile = value;
        }
    }
}