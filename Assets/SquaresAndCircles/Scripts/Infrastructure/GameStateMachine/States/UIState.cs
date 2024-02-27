namespace SquaresAndCircles.Infrastructure.GameStateMachine.States
{
    public class UIState : IState
    {
        private const string UI_SCENE = "ui_scene";

        private readonly SceneLoader      _sceneLoader;
        private          GameStateMachine _stateMachine;

        public UIState(GameStateMachine stateMachine, SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader  = sceneLoader;
        }

        public void Enter()
        {
            _sceneLoader.Load(UI_SCENE, EnterPrewarm);
        }

        public void Exit()
        {
        }

        private void EnterPrewarm() =>
            _stateMachine.Enter<PrewarmGameplayState>();
    }
}