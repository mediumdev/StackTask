using Game.Gameplay.Components;
using Game.Gameplay.View;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.Gameplay.Systems
{
    public sealed class ResourceTransferSystem : IEcsRunSystem
    {
        private const float epsilon = 0.01f;
        private readonly IConfig _config = null;
        private readonly EcsFilter<Resource, Transfer, UnityObject<ResourceView>> _resourceObjects = default;

        public void Run()
        {
            foreach (var j in _resourceObjects)
            {
                ref var resourceEntity = ref _resourceObjects.GetEntity(j);
                ref var resource = ref _resourceObjects.Get1(j);
                ref var transfer = ref _resourceObjects.Get2(j);
                ref var resourceView = ref _resourceObjects.Get3(j).value;

                if (resourceView == null)
                {
                    continue;
                }

                resourceView.transform.position = Vector3.MoveTowards(resourceView.transform.position, transfer.position, Time.deltaTime * _config.resourceTransferSpeed);

                if (Vector3.Distance(transfer.position, resourceView.transform.position) < epsilon)
                {
                    resourceView.transform.position = transfer.position;
                    resourceEntity.Del<Transfer>();
                }
            }
        }
    }
}