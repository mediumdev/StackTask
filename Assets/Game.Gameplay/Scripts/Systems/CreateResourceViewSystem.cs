using Game.Gameplay.Components;
using Game.Gameplay.View;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.Gameplay.Systems
{
    public sealed class CreateResourceViewSystem : IEcsRunSystem
    {
        private readonly ISceneContext _scene = default;

        private readonly EcsFilter<Resource>.Exclude<UnityObject<ResourceView>> _resourceObjects = default;

        public void Run()
        {
            foreach (var i in _resourceObjects)
            {
                ref var resourceEntity = ref _resourceObjects.GetEntity(i);
                ref var resource = ref _resourceObjects.Get1(i);

                if (resource.parentStackEntity == EcsEntity.Null)
                {
                    continue;
                }

                var parentStack = resource.parentStackEntity.Get<Stack>();

                var spawnResourcePrefab = parentStack.spawnResourcePrefab;

                if (spawnResourcePrefab == null)
                {
                    continue;
                }

                var view = Object.Instantiate(spawnResourcePrefab, parentStack.transform.position, Quaternion.identity, _scene.resourcesViewRoot);

                resourceEntity.Get<UnityObject<ResourceView>>().value = view;
            }
        }
    }
}
