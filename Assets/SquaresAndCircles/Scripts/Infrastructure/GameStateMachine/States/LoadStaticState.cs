using System.Collections.Generic;
using SquaresAndCircles.Infrastructure.AssetProviding;

namespace SquaresAndCircles.Infrastructure.GameStateMachine.States
{
    public class LoadStaticState : IState
    {
        private readonly GameStateMachine   _stateMachine;
        private readonly List<IAssetLoader> _assetLoaders;

        public LoadStaticState(GameStateMachine stateMachine, List<IAssetLoader> assetLoaders)
        {
            _stateMachine = stateMachine;
            _assetLoaders = assetLoaders;
        }

        public void Enter()
        {
            LoadData();
            _stateMachine.Enter<LoadSavesState>();
        }

        private void LoadData()
        {
            LoadStaticData();
        }

        private void LoadStaticData()
        {
            foreach (IAssetLoader assetLoader in _assetLoaders)
            {
                assetLoader.Load();
            }
        }
    }
}