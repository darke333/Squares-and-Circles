using SquaresAndCircles.Infrastructure.GameStateMachine.States;
using UnityEngine;
using Zenject;

namespace SquaresAndCircles.Infrastructure.GameStateMachine
{
    public class EntryPoint : IInitializable
    {
        private readonly GameStateMachine _gameStateMachine;

        public EntryPoint(GameStateMachine gameStateMachine) => 
            _gameStateMachine = gameStateMachine;

        public void Initialize()
        {
            Application.targetFrameRate = Screen.currentResolution.refreshRate;
            
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
            _gameStateMachine.Enter<LoadStaticState>();
        }
    }
    
}