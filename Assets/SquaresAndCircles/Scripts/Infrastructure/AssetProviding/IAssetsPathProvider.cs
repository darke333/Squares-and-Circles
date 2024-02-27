using System;

namespace SquaresAndCircles.Infrastructure.AssetProviding
{
    public interface IAssetsPathProvider
    {
        public string GetPath(Type type);
    }
}