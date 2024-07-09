using Game.Gameplay.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.Gameplay.Systems
{
    public sealed class StackResourceTransferSystem : IEcsRunSystem
    {
        private readonly EcsFilter<Resource> _resourceObjects = default;
        private readonly EcsFilter<Stack> _stackObjects = default;

        public void Run()
        {
            foreach (var i in _stackObjects)
            {
                ref var stackEntity = ref _stackObjects.GetEntity(i);
                ref var stack = ref _stackObjects.Get1(i);

                int num = 0;

                foreach (var j in _resourceObjects)
                {
                    ref var resourceEntity = ref _resourceObjects.GetEntity(j);
                    ref var resource = ref _resourceObjects.Get1(j);

                    if (resource.parentStackEntity == EcsEntity.Null)
                    {
                        continue;
                    }

                    var parentStack = resource.parentStackEntity.Get<Stack>();

                    if (stack.transform == null || parentStack.transform == null)
                    {
                        continue;
                    }

                    if (stack.transform == parentStack.transform)
                    {
                        int sizeX = stackEntity.Get<Stack>().sizeX;
                        int sizeY = stackEntity.Get<Stack>().sizeY;

                        float transferX = num % sizeX;
                        float transferY = num / (sizeX * sizeY);
                        float transferZ = 0 - (num - num / (sizeX * sizeY) * (sizeX * sizeY)) / sizeX;

                        float offsetX = sizeX * stack.columnSizeX / 2f - stack.columnSizeX / 2f;
                        float offsetZ = sizeY * stack.columnSizeZ / 2f - stack.columnSizeZ / 2f;

                        Vector3 transferPosition = new Vector3(transferX * stack.columnSizeX - offsetX,
                                                               transferY * stack.columnSizeY,
                                                               transferZ * stack.columnSizeZ + offsetZ);

                        resourceEntity.Get<Transfer>().position = transferPosition + parentStack.transform.position;

                        num++;
                    }
                }

                stackEntity.Get<Sorted>();
            }
        }
    }
}