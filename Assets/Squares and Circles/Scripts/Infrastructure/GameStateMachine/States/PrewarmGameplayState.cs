using System.Collections.Generic;

namespace Infrastructure.GameStateMachine.States
{
    public class PrewarmGameplayState : IState
    {
        private readonly List<IInitializablePrewarm> _prewarms;
        private readonly SceneLoader _sceneLoader;

        public PrewarmGameplayState(List<IInitializablePrewarm> prewarms, SceneLoader sceneLoader)
        {
            _prewarms = prewarms;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            InitSystems();
            _sceneLoader.Load("GamePlayScene", EnterGameplay);
        }

        private void InitSystems()
        {
            foreach (IInitializablePrewarm prewarm in _prewarms)
            {
                prewarm.Initialize();
            }
        }

        private void EnterGameplay()
        {
        }
    }
}