using System.Collections.Generic;
using SquaresAndCircles.Infrastructure.Saving;

namespace SquaresAndCircles.Infrastructure.GameStateMachine.States
{
    public class LoadSavesState : IState
    {
        private readonly GameStateMachine   _stateMachine;
        private readonly List<ISaverLoader> _assetLoaders;

        public LoadSavesState(GameStateMachine stateMachine, List<ISaverLoader> assetLoaders)
        {
            _stateMachine      = stateMachine;
            _assetLoaders = assetLoaders;
        }

        public void Enter()
        {
            LoadSaves();
            _stateMachine.Enter<UIState>();
        }

        private void LoadSaves()
        {
            foreach (ISaverLoader assetLoader in _assetLoaders)
            {
                assetLoader.Load();
            }
        }
    }
}