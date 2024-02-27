using System.Collections.Generic;
using SquaresAndCircles.GamePlay.Spawner;

namespace SquaresAndCircles.Infrastructure.GameStateMachine.States
{
    public class PrewarmGameplayState : IState
    {
        private const string GAMEPLAY_SCENE = "gameplay";

        private readonly List<IInitializablePrewarm> _prewarms;
        private readonly SceneLoader                 _sceneLoader;
        private readonly ISquareSpawner              _squareSpawner;

        public PrewarmGameplayState(List<IInitializablePrewarm> prewarms, SceneLoader sceneLoader,
                                    ISquareSpawner squareSpawner)
        {
            _prewarms      = prewarms;
            _sceneLoader   = sceneLoader;
            _squareSpawner = squareSpawner;
        }

        public void Enter()
        {
            InitSystems();
            _sceneLoader.LoadAdditive(GAMEPLAY_SCENE, EnterGameplay);
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
            _squareSpawner.Initialize();
            _squareSpawner.StartSpawner();
        }
    }
}