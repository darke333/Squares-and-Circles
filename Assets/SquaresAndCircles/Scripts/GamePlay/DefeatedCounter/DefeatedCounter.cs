using System;
using SquaresAndCircles.Infrastructure.Saving;
using UnityEngine;

namespace SquaresAndCircles.GamePlay.DefeatedCounter
{
    public class DefeatedCounter : IDefeatedGetter, IDefeatedSetter, ISaverLoader, ISaver
    {
        private const string DEFEATED = "defeated";

        public int               Defeated { get; private set; }
        public event Action<int> ValueChanged;

        public void AddDefeated(int count = 1)
        {
            Defeated += count;
            ValueChanged?.Invoke(Defeated);
        }

        public void Load() => Defeated = PlayerPrefs.HasKey(DEFEATED) ? PlayerPrefs.GetInt(DEFEATED) : 0;

        public void Save() => PlayerPrefs.SetInt(DEFEATED, Defeated);
    }
}