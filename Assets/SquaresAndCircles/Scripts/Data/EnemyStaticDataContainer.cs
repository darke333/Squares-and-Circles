using SquaresAndCircles.GamePlay.Enemy;
using UnityEngine;

namespace SquaresAndCircles.Data
{
    [CreateAssetMenu(fileName = "EnemyStaticDataContainer",
                     menuName = "ScriptableObjects/Data/EnemyStaticDataContainer")]
    public class EnemyStaticDataContainer : ScriptableObject
    {
        public Enemy Square       => _square;
        public float SpawnSeconds => _spawnSeconds;
        public int   MaxSpawned   => _maxSpawned;

        [SerializeField] private Enemy _square;

        [SerializeField] private float _spawnSeconds = 1;

        [SerializeField] private int _maxSpawned;
    }
}