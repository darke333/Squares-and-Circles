using System;

namespace SquaresAndCircles.GamePlay.DefeatedCounter
{
    public interface IDefeatedGetter
    {
        public int               Defeated { get; }
        public event Action<int> ValueChanged;
    }
}