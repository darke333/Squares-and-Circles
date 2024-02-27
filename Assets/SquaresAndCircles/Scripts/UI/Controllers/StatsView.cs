using TMPro;
using UnityEngine;

namespace SquaresAndCircles.UI.Controllers
{
    public class StatsView: MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _defeatedValue;
        [SerializeField] private TextMeshProUGUI _distanceValue;

        public void SetDefeatedValue(string value) => _defeatedValue.text = value;

        public void SetDistanceValue(string value) => _distanceValue.text = value;
    }
}