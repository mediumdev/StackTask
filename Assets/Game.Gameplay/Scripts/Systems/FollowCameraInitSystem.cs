using Game.Gameplay.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.Gameplay.Systems
{
    public sealed class FollowCameraInitSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world = default;

        public void Init()
        {
            var cameraObjects = GameObject.FindGameObjectsWithTag("FollowCamera");

            foreach (var camera in cameraObjects)
            {
                var cameraEntity = _world.NewEntity();
                var cameraView = camera.GetComponent<FollowCameraView>();

                cameraEntity.Replace(new FollowCamera {smoothTime = cameraView.smoothTime,
                                                       followOffset = cameraView.followOffset})
                            .Replace(new UnityObject<FollowCameraView> { value = cameraView });
            }
        }
    }
}