using Game.Gameplay.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.Gameplay.Systems
{
    public sealed class RotationSystem : IEcsRunSystem
    {
        private readonly EcsFilter<Rotation, Direction, UnityObject<GameObject>> _rotationObjects = default;

        public void Run()
        {
            foreach (var i in _rotationObjects)
            {
                ref var rotationEntity = ref _rotationObjects.GetEntity(i);
                ref var rotationSpeed = ref _rotationObjects.Get1(i).speed;
                ref var direction = ref _rotationObjects.Get2(i).value;
                ref var rotationObject = ref _rotationObjects.Get3(i).value;

                Vector3 targetDirection = Vector3.RotateTowards(rotationObject.transform.forward, direction, rotationSpeed * Time.deltaTime, 0.0f);
                rotationObject.transform.rotation = Quaternion.LookRotation(targetDirection);
            }
        }
    }
}