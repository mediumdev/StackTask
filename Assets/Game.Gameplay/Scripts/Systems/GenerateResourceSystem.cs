using Game.Gameplay.Components;
using Leopotam.Ecs;

namespace Game.Gameplay.Systems
{
    public sealed class GenerateResourceSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = default;
        private readonly EcsFilter<Stack, Count>.Exclude<Timer<TimerBetweenGenerate>, Full> _stackObjects = default;

        public void Run()
        {
            foreach (var i in _stackObjects)
            {
                ref var stackEntity = ref _stackObjects.GetEntity(i);
                ref var stack = ref _stackObjects.Get1(i);
                ref var count = ref _stackObjects.Get2(i);
                
                if (stack.spawnResourcePrefab == null)
                {
                    continue;
                }

                var resource = _world.NewEntity();
                resource.Get<Resource>().parentStackEntity = stackEntity;
                resource.Get<Resource>().resourceType = stack.spawnResourcePrefab.resourceType;
                count.value++;

                stackEntity.Get<Timer<TimerBetweenGenerate>>().timeLeftSec = stack.spawnDelay;
                stackEntity.Del<Sorted>();
            }
        }
    }
}