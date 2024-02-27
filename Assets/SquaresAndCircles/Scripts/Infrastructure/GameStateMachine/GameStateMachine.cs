using System.Collections.Generic;
using System.Linq;

namespace SquaresAndCircles.Infrastructure.GameStateMachine
{
    public class GameStateMachine
    {
        private readonly StateFactory _stateFactory;
        private          IState       _activeState;

        public GameStateMachine(StateFactory stateFactory)
        {
            _stateFactory = stateFactory;
        }

        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            if (state != null && _activeState is IStateChangeable)
            {
                (state as IStateChangeable).SetStateMachine(this);
            }

            state.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
        {
            TState state = ChangeState<TState>();
            state.Enter(payload);
        }

        private TState ChangeState<TState>() where TState : class, IState
        {
            if (_activeState is IStateExitable exitable)
            {
                exitable.Exit();
            }

            TState state = GetState<TState>();
            _activeState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class =>
            _stateFactory.CreateState<TState>();
    }
}