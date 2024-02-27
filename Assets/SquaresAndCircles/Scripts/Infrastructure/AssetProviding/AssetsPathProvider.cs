using System;
using System.Collections.Generic;
using SquaresAndCircles.Data;

namespace SquaresAndCircles.Infrastructure.AssetProviding
{
    public class AssetsPathProvider : IAssetsPathProvider
    {
        private readonly Dictionary<Type, string> _staticsPaths = new()
        {
            { typeof(PlayerStaticDataContainer), AssetsPaths.PLAYER },
            { typeof(EnemyStaticDataContainer), AssetsPaths.ENEMY },
        };

        public string GetPath(Type type)
        {
            return _staticsPaths[type];
        }
    }
}