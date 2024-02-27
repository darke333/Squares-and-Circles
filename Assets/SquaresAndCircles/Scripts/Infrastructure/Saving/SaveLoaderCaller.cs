using System.Collections.Generic;

namespace SquaresAndCircles.Infrastructure.Saving
{
    public class SaveLoaderCaller : ISaveLoaderCaller
    {
        private readonly List<ISaverLoader> _loaders;

        public SaveLoaderCaller(List<ISaverLoader> loaders)
        {
            _loaders = loaders;
        }

        public void LoadSaves()
        {
            foreach (ISaverLoader loader in _loaders)
            {
                loader.Load();
            }
        }
    }
}