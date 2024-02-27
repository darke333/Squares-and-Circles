using SquaresAndCircles.GamePlay.DefeatedCounter;
using SquaresAndCircles.GamePlay.Distance;
using SquaresAndCircles.UI.Controllers;

namespace SquaresAndCircles.UI.View
{
    public class StatsViewController
    {
        private readonly IDefeatedGetter _defeatedGetter;
        private readonly IDistanceGetter _distanceGetter;

        private StatsView _statsView;

        public StatsViewController(IDefeatedGetter defeatedGetter, IDistanceGetter distanceGetter)
        {
            _defeatedGetter = defeatedGetter;
            _distanceGetter = distanceGetter;
        }

        public void InitializeView(StatsView statsView)
        {
            _statsView = statsView;
            
            SetStartView();
            ConnectToEvents();
        }

        private void SetStartView()
        {
            SetDefeatedValue(_defeatedGetter.Defeated);
            SetDistanceValue(_distanceGetter.Distance);
        }

        private void ConnectToEvents()
        {
            _defeatedGetter.ValueChanged += SetDefeatedValue;
            _distanceGetter.ValueChanged += SetDistanceValue;
        }

        private void SetDefeatedValue(int value) => _statsView.SetDefeatedValue(value.ToString());
        private void SetDistanceValue(float value) => _statsView.SetDistanceValue(((int)value).ToString());
    }
}