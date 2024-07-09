using Leopotam.Ecs;
using static Game.Gameplay.View.ResourceView;

namespace Game.Gameplay.Components
{
    public struct Resource
    {
        public ResourceType resourceType;
        public EcsEntity parentStackEntity;
    }
}

