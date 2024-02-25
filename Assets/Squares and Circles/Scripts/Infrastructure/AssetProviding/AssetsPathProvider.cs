using System;
using System.Collections.Generic;

namespace Infrastructure.AssetProviding
{
    public class AssetsPathProvider : IAssetsPathProvider
    {
        private readonly Dictionary<Type, string> _staticsPaths = new()
        {

        };

        public string GetPath(Type type)
        {
            return _staticsPaths[type];
        }
    }
}