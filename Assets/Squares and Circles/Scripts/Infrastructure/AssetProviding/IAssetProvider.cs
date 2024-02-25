namespace Infrastructure.AssetProviding
{
    public interface IAssetProvider<T>
    {
        public T StaticData { get; }
    }
}