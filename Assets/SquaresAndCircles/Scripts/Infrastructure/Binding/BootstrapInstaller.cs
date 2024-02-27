using SquaresAndCircles.Data;
using SquaresAndCircles.GamePlay.DefeatedCounter;
using SquaresAndCircles.GamePlay.Distance;
using SquaresAndCircles.GamePlay.Spawner;
using SquaresAndCircles.Infrastructure.AssetProviding;
using SquaresAndCircles.Infrastructure.GameStateMachine;
using SquaresAndCircles.Infrastructure.GameStateMachine.States;
using SquaresAndCircles.Infrastructure.InputSystem;
using SquaresAndCircles.Infrastructure.Saving;
using SquaresAndCircles.Services;
using SquaresAndCircles.UI.View;
using Zenject;

namespace SquaresAndCircles.Infrastructure.Binding
{
    public class BootstrapInstaller : MonoInstaller, ICoroutineRunner
    {
        public override void InstallBindings()
        {
            RegisterAssets();
            RegisterStates();
            RegisterInfrastructureServices();
            RegisterStaticServices();
            RegisterUI();
            RegisterInput();
            RegisterCounter();
            RegisterSaveSystem();
            RegisterSpawner();
            RegisterServices();
        }

        private void RegisterSpawner()
        {
            Container.BindInterfacesTo<SquareSpawner>().AsSingle();
        }

        private void RegisterUI()
        {
            Container.BindInterfacesAndSelfTo<StatsViewController>().AsTransient();
        }

        private void RegisterInfrastructureServices()
        {
            Container.Bind<ICoroutineRunner>().FromInstance(this).AsSingle();
            Container.Bind<SceneLoader>().AsSingle();
        }

        private void RegisterStates()
        {
            Container.Bind<IInitializable>().To<EntryPoint>().AsSingle();
            Container.Bind<GameStateMachine.GameStateMachine>().AsSingle();
            Container.Bind<StateFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoadStaticState>().AsTransient();
            Container.BindInterfacesAndSelfTo<PrewarmGameplayState>().AsTransient();
            Container.BindInterfacesAndSelfTo<UIState>().AsTransient();
            Container.BindInterfacesAndSelfTo<LoadSavesState>().AsTransient();
        }

        private void RegisterStaticServices()
        {
            Container.BindInterfacesTo<AssetsPathProvider>().AsSingle();
        }

        private void RegisterAssets()
        {
            Container.BindInterfacesTo<AssetProvider<PlayerStaticDataContainer>>().AsSingle();
            Container.BindInterfacesTo<AssetProvider<EnemyStaticDataContainer>>().AsSingle();
        }

        private void RegisterInput()
        {
            Container.BindInterfacesTo<InputProvider>().AsSingle();
        }

        private void RegisterCounter()
        {
            Container.BindInterfacesTo<DefeatedCounter>().AsSingle();
            Container.BindInterfacesTo<DistanceCounter>().AsSingle();
        }

        private void RegisterSaveSystem()
        {
            Container.Bind<SavingCaller>().AsSingle().NonLazy();
            Container.BindInterfacesTo<SaveLoaderCaller>().AsSingle();
        }

        private void RegisterServices()
        {
            Container.BindInterfacesTo<ScreenBounder>().AsSingle().NonLazy();
        }
    }
}