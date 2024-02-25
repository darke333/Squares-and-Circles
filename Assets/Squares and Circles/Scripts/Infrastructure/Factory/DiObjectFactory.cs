using UnityEngine;
using Zenject;

namespace Infrastructure.Factory
{
    public class DiObjectFactory
    {
        private readonly DiContainer _container;

        public DiObjectFactory(DiContainer container)
        {
            _container = container;
        }
        
        public GameObject Instantiate(GameObject original) =>
            _container.InstantiatePrefab(original);
        
        public GameObject Instantiate(GameObject original, Transform parent) =>
            _container.InstantiatePrefab(original, parent);

        public GameObject Instantiate(GameObject original, Vector3 position, Quaternion rotation) =>
            _container.InstantiatePrefab(original, position, rotation, null);

        public GameObject Instantiate(GameObject original, Vector3 position, Quaternion rotation, Transform parent) =>
            _container.InstantiatePrefab(original, position, rotation, parent);
        
        public T Instantiate<T>(T original) where T : Object =>
            _container.InstantiatePrefabForComponent<T>(original);

        public T Instantiate<T>(T original, Vector3 position, Quaternion rotation) where T : Object =>
            _container.InstantiatePrefabForComponent<T>(original, position, rotation, null);
        
        public T Instantiate<T>(T original, Vector3 position, Quaternion rotation, Transform parent) where T : Object =>
            _container.InstantiatePrefabForComponent<T>(original, position, rotation, parent);
        
        public T Instantiate<T>(T original, Transform parent) where T : Object =>
            _container.InstantiatePrefabForComponent<T>(original, parent);
    }
}