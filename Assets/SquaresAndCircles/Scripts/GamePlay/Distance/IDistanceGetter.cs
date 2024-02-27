using System;

namespace SquaresAndCircles.GamePlay.Distance
{
    public interface IDistanceGetter
    {
        public float               Distance { get; }
        public event Action<float> ValueChanged;
    }
}