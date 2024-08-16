using Scripts.Infrastructure.Services;

namespace Scripts.Infrastructure.State
{
    public interface IGameStateMashine : IService
    {
        void Enter<TState, TPayLoad>(TPayLoad payLoad) where TState : class, IPayLoadedState<TPayLoad>;
        void Enter<TState>() where TState : class, IState;
    }
}