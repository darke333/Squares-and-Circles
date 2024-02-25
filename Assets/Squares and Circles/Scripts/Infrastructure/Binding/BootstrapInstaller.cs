using Infrastructure.AssetProviding;
using Infrastructure.GameStateMachine;
using Infrastructure.GameStateMachine.States;
using Zenject;

namespace Infrastructure.Binding
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
        }

        private void RegisterUI()
        {
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
            Container.BindInterfacesAndSelfTo<LoadStaticState>().AsTransient();
            Container.BindInterfacesAndSelfTo<PrewarmGameplayState>().AsTransient();
        }

        private void RegisterStaticServices()
        {
            Container.BindInterfacesTo<AssetsPathProvider>().AsSingle();
        }

        private void RegisterAssets()
        {

        }
    }
}