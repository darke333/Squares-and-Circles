using SquaresAndCircles.GamePlay.Movables.Player;
using SquaresAndCircles.Infrastructure.Binding;
using SquaresAndCircles.Services;
using UnityEngine;
using Zenject;

namespace SquaresAndCircles.GamePlay
{
    public class GamePlayInstaller : MonoInstaller<GamePlayInstaller>
    {
        [SerializeField] private Camera         _camera;
        [SerializeField] private PlayerMovement _playerMovement;

        public override void InstallBindings()
        {
            BindCamera();
            BindPlayer();

            SetCamera();
        }

        private void BindCamera()
        {
            Container.Bind<Camera>().FromInstance(_camera).AsSingle();
        }

        private void BindPlayer()
        {
            Container.Bind<PlayerMovement>().FromInstance(_playerMovement).AsSingle();
        }

        private void SetCamera()
        {
            Container.ResolveFromProjectContainer<IScreenBounderInstaller>().SetCamera(_camera);
        }
    }
}