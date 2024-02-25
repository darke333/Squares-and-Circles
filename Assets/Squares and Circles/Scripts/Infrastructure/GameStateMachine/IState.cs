namespace Infrastructure.GameStateMachine
{
    public interface IState 
    {
        public void Enter();
    }
    
    public interface IStateExitable
    {
        public void Exit();
    }
    
    public interface IStateChangeable
    {
        public void SetStateMachine(GameStateMachine gameStateMachine);
    }
}