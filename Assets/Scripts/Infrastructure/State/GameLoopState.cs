namespace Scripts.Infrastructure.State
{
    public class GameLoopState : IState
    {
        private readonly GameStateMashine _gameStateMashine;

        public GameLoopState(GameStateMashine gameStateMashine)
        {
            _gameStateMashine = gameStateMashine;
        }

        public void Enter()
        {
            
        }

        public void Exit()
        {
            
        }
    }
}