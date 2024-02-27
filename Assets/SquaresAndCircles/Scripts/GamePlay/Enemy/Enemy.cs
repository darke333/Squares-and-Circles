using System;
using SquaresAndCircles.GamePlay.DefeatedCounter;
using UnityEngine;

namespace SquaresAndCircles.GamePlay.Enemy
{
    public class Enemy : MonoBehaviour
    {
        private const string PLAYER_TAG = "Player";

        public event Action OnDestroyEvent;

        public  SpriteRenderer  SpriteRenderer;
        private IDefeatedSetter _defeatedSetter;

        private void OnDestroy()
        {
            OnDestroyEvent?.Invoke();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag(PLAYER_TAG)) return;

            _defeatedSetter.AddDefeated();
            Destroy(gameObject);
        }

        public void SetDefeatCounter(IDefeatedSetter defeatedSetter)
        {
            _defeatedSetter = defeatedSetter;
        }
    }
}