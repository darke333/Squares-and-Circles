using SquaresAndCircles.Infrastructure.GameStateMachine;

namespace SquaresAndCircles.Infrastructure.InputSystem
{
    public class InputProvider : IInputProvider, IInitializablePrewarm
    {
        public  IInputEvents InputEvents => _inputEvents;
        private IInputEvents _inputEvents;

        public void Initialize()
        {
#if UNITY_EDITOR
            _inputEvents = new InputProviderEditor();
#else
            _inputEvents = new InputProviderMobile();
#endif
        }
    }
}