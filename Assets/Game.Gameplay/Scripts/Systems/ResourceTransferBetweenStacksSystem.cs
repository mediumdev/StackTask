using Game.Gameplay.Components;
using Game.Gameplay.View;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.Gameplay.Systems
{
    public sealed class ResourceTransferBetweenStacksSystem : IEcsRunSystem
    {
        private readonly IConfig _config = default;
        private readonly EcsFilter<Resource, UnityObject<ResourceView>> _resourceObjects = default;
        private readonly EcsFilter<Stack, Count>.Exclude<Full> _stackObjects = default;

        public void Run()
        {
            foreach (var i in _resourceObjects)
            {
                ref var resourceEntity = ref _resourceObjects.GetEntity(i);
                ref var resource = ref _resourceObjects.Get1(i);
                var resourceView = _resourceObjects.Get2(i).value;
                var parentStack = resource.parentStackEntity.Get<Stack>();

                foreach (var j in _stackObjects)
                {
                    ref var stackEntity = ref _stackObjects.GetEntity(j);
                    ref var stack = ref _stackObjects.Get1(j);
                    ref var count = ref _stackObjects.Get2(j);
                    var stackView = stackEntity.Get<UnityObject<StackView>>().value;

                    if (stackView == null)
                    {
                        continue;
                    }

                    if (stack.takeResourceType == ResourceView.ResourceType.None)
                    {
                        continue;
                    }

                    if (stack.take == false)
                    {
                        continue;
                    }

                    if (parentStack.give == false)
                    {
                        continue;
                    }

                    if (stack.takeResourceType != resource.resourceType)
                    {
                        continue;
                    }

                    if (Vector3.Distance(resourceView.transform.position, stackView.transform.position) < _config.stackTransferDistance)
                    {
                        Transform lastTransform = parentStack.transform;

                        if (lastTransform == stack.transform)
                        {
                            continue;
                        }

                        resourceEntity.Get<Resource>().parentStackEntity.Get<Count>().value--;
                        resourceEntity.Get<Resource>().parentStackEntity = stackEntity;
                        count.value++;
                        stackEntity.Del<Sorted>();

                        break;
                    }
                }
            }
        }
    }
}