namespace SquaresAndCircles.Infrastructure.InputSystem
{
    public interface IInputProvider
    {
        public IInputEvents InputEvents { get; }
    }
}