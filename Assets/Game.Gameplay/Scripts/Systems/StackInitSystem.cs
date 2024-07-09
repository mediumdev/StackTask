using Game.Gameplay.Components;
using Game.Gameplay.View;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.Gameplay.Systems
{
    public sealed class StackInitSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world = default;

        public void Init()
        {
            var stackObjects = GameObject.FindGameObjectsWithTag("Stack");

            foreach (var stack in stackObjects)
            {
                var stackEntity = _world.NewEntity();
                var transform = stack.transform;
                var stackView = stack.GetComponent<StackView>();

                stackEntity.Replace(new Stack {transform = transform,
                                               takeResourceType = stackView.takeResourceType,
                                               spawnResourcePrefab = stackView.spawnResourcePrefab,
                                               spawnDelay = stackView.spawnDelay,
                                               max = stackView.max,
                                               sizeX = stackView.sizeX,
                                               sizeY = stackView.sizeY,
                                               give = stackView.give,
                                               take = stackView.take,
                                               columnSizeX = stackView.columnSizeX,
                                               columnSizeY = stackView.columnSizeY,
                                               columnSizeZ = stackView.columnSizeZ})
                           .Replace(new UnityObject<StackView>() { value = stackView })
                           .Replace(new Count())
                           .Replace(new Timer<TimerBetweenGenerate> {timeLeftSec = stackView.spawnDelay});
            }
        }
    }
}