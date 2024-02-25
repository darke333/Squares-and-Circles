using System;

namespace Infrastructure.AssetProviding
{
    public interface IAssetsPathProvider
    {
        public string GetPath(Type type);
    }
}