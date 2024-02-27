using Zenject;

namespace SquaresAndCircles.Infrastructure.Binding
{
    public static class DIExtension
    {
        private const int PROJECT_CONTAINER_ID = 0;

        public static TContract ResolveFromProjectContainer<TContract>(this DiContainer container) => 
            (TContract)container.GetProjectContainer().Resolve(typeof(TContract));
        
        private static DiContainer GetProjectContainer(this DiContainer container) => 
            container.ParentContainers[PROJECT_CONTAINER_ID];
    }
}