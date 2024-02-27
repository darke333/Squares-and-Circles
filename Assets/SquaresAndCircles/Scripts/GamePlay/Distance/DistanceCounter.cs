using System;
using SquaresAndCircles.Infrastructure.Saving;
using UnityEngine;

namespace SquaresAndCircles.GamePlay.Distance
{
    public class DistanceCounter : IDistanceGetter, IDistanceSetter, ISaverLoader, ISaver
    {
        private const string DISTANCE = "distance";

        public float               Distance { get; private set; }
        public event Action<float> ValueChanged;

        public void AddDistance(float distance)
        {
            Distance += distance;
            ValueChanged?.Invoke(Distance);
        }

        public void Load() => Distance = PlayerPrefs.HasKey(DISTANCE) ? PlayerPrefs.GetFloat(DISTANCE) : 0;

        public void Save() => PlayerPrefs.SetFloat(DISTANCE, Distance);
    }
}