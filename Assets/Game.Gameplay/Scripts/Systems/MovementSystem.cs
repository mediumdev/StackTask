using Game.Gameplay.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.Gameplay.Systems
{
    public sealed class MovementSystem : IEcsRunSystem
    {
        private readonly EcsFilter<Movement, Direction, UnityObject<GameObject>> _moveObjects = default;

        public void Run()
        {
            foreach (var i in _moveObjects)
            {
                ref var moveEntity = ref _moveObjects.GetEntity(i);
                ref var moveSpeed = ref _moveObjects.Get1(i).speed;
                ref var direction = ref _moveObjects.Get2(i).value;
                ref var moveObject = ref _moveObjects.Get3(i).value;

                moveObject.transform.position += direction * Time.deltaTime * moveSpeed;
            }
        }
    }
}