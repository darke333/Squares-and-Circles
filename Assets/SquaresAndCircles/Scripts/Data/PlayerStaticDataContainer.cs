using UnityEngine;

namespace SquaresAndCircles.Data
{
    [CreateAssetMenu(fileName = "PlayerStaticDataContainer",
                     menuName = "ScriptableObjects/Data/PlayerStaticDataContainer")]
    public class PlayerStaticDataContainer : ScriptableObject
    {
        public float StartSpeed   => _startSpeed;
        public float EndSpeed     => _endSpeed;
        public float Acceleration => _acceleration;

        [SerializeField] private float _startSpeed   = 0.5f;
        [SerializeField] private float _endSpeed     = 0.2f;
        [SerializeField] private float _acceleration = 0.01f;
    }
}