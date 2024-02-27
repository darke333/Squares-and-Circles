using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using SquaresAndCircles.Data;
using SquaresAndCircles.GamePlay.DefeatedCounter;
using SquaresAndCircles.Infrastructure.AssetProviding;
using SquaresAndCircles.Services;
using UniRx.Triggers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SquaresAndCircles.GamePlay.Spawner
{
    public class SquareSpawner : ISquareSpawner
    {
        private readonly IAssetProvider<EnemyStaticDataContainer> _assetProvider;
        private readonly IScreenBounder                           _screenBounder;
        private readonly IDefeatedSetter                          _defeatCounter;

        private Enemy.Enemy _square       => _assetProvider.StaticData.Square;
        private float       _spawnSeconds => _assetProvider.StaticData.SpawnSeconds;
        private int         _spawnMax     => _assetProvider.StaticData.MaxSpawned;

        private CancellationTokenSource _spawnerCancel;
        private ScreenBounds            _bounds;
        private int                     _spawned;

        public SquareSpawner(IScreenBounder screenBounder, IAssetProvider<EnemyStaticDataContainer> assetProvider,
                             IDefeatedSetter defeatCounter)
        {
            _screenBounder = screenBounder;
            _assetProvider = assetProvider;
            _defeatCounter = defeatCounter;
        }

        public void Initialize()
        {
            SetScreenBounds();
        }

        public void StartSpawner()
        {
            _spawnerCancel = new CancellationTokenSource();
            RunLoop(_spawnerCancel.Token);
        }

        public void StopSpawner()
        {
            _spawnerCancel.Cancel();
        }

        private void SetScreenBounds()
        {
            _bounds = _screenBounder.GetBounds(_square.SpriteRenderer);
        }

        private async UniTask RunLoop(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                await UniTask.Delay(TimeSpan.FromSeconds(_spawnSeconds), cancellationToken: cancellationToken);
                Spawn();
            }
        }

        private void Spawn()
        {
            if (_spawned >= _spawnMax)
                return;

            float x = Random.Range(_bounds.MinX, _bounds.MaxX);
            float y = Random.Range(_bounds.MinX, _bounds.MaxY);

            Enemy.Enemy created = GameObject.Instantiate(_square, position: new Vector3(x, y, 0), new Quaternion());
            created.SetDefeatCounter(_defeatCounter);
            created.OnDestroyEvent += () => _spawned--;

            _spawned++;
        }
    }
}