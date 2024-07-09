using Game.Gameplay.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.Gameplay.Systems
{
    public sealed class FollowCameraSystem : IEcsRunSystem
    {
        private readonly EcsFilter<UnityObject<GameObject>, Follow> _followObjects = default;
        private readonly EcsFilter<FollowCamera, UnityObject<FollowCameraView>> _cameraObjects = default;

        private Vector3 currentVelocity;

        public void Run()
        {
            foreach (var i in _followObjects)
            {
                ref var followObject = ref _followObjects.Get1(i).value;

                foreach (var j in _cameraObjects)
                {
                    ref var cameraObject = ref _cameraObjects.Get1(j);
                    ref var cameraView = ref _cameraObjects.Get2(j).value;

                    var currentPos = cameraView.transform.position;
                    currentPos = Vector3.SmoothDamp(currentPos, followObject.transform.position + cameraObject.followOffset, ref currentVelocity, cameraObject.smoothTime);
                    cameraView.transform.position = currentPos;
                }
            }
        }
    }
}