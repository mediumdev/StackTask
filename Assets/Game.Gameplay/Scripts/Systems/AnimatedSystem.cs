using Game.Gameplay.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.Gameplay.Systems
{
    public sealed class AnimatedSystem : IEcsRunSystem
    {
        private readonly IConfig _config = default;
        private readonly EcsFilter<Animated, Direction, Movement> _animatedObjects = default;

        public void Run()
        {
            foreach (var i in _animatedObjects)
            {
                ref var animatedEntity = ref _animatedObjects.GetEntity(i);
                ref var animator = ref _animatedObjects.Get1(i).animator;
                ref var directin = ref _animatedObjects.Get2(i).value;

                animator.SetBool(_config.animationRunParamName, directin != Vector3.zero);
            }
        }
    }
}