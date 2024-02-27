using SquaresAndCircles.Infrastructure.Binding;
using SquaresAndCircles.UI.Controllers;
using SquaresAndCircles.UI.View;
using UnityEngine;
using Zenject;

namespace SquaresAndCircles.UI
{
    public class ViewsInstaller : MonoInstaller<ViewsInstaller>
    {
        [SerializeField] StatsView _statsViewController;

        public override void InstallBindings()
        {
            BindUI();
        }

        private void BindUI()
        {
            InitializeMainScreenViews();
        }

        private void InitializeMainScreenViews()
        {
            Container.Bind<StatsView>().FromInstance(_statsViewController).AsSingle();
            Container.ResolveFromProjectContainer<StatsViewController>().InitializeView(_statsViewController);
        }
    }
}