﻿namespace Scripts.Infrastructure.State
{
    public interface IState : IExitebleState
    {
        void Enter();
    }

    public interface IPayLoadedState<TPayLoad> : IExitebleState
    {
        void Enter(TPayLoad payLoad);
    }

    public interface IExitebleState
    {
        void Exit();
    }
}