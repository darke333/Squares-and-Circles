using Zenject;

namespace SquaresAndCircles.Infrastructure.GameStateMachine
{
    public class StateFactory
    {
        private readonly DiContainer _container;

        StateFactory(DiContainer container)
        {
            _container = container;
        }

        public TState CreateState<TState>() => _container.Resolve<TState>();
    }
}