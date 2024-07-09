using Game.Gameplay.Components;
using Leopotam.Ecs;

namespace Game.Gameplay.Systems
{
    public sealed class StackSystem : IEcsRunSystem
    {
        private readonly EcsFilter<Stack, Count> _stackObjects = default;

        public void Run()
        {
            foreach (var i in _stackObjects)
            {
                ref var stackEntity = ref _stackObjects.GetEntity(i);
                ref var stack = ref _stackObjects.Get1(i);
                ref var count = ref _stackObjects.Get2(i);

                if (count.value >= stack.max)
                {
                    stackEntity.Get<Full>();
                }
                else
                {
                    stackEntity.Del<Full>();
                }
            }
        }
    }
}