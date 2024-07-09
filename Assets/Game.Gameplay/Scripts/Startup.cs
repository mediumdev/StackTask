using Game.Gameplay;
using Game.Gameplay.Components;
using Game.Gameplay.Systems;
using Game.UI.Components;
using Game.UI.Systems;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.Ecs
{
    [RequireComponent(typeof(SceneContext))]
    sealed class Startup : MonoBehaviour
    {
        private EcsWorld _world;
        private EcsSystems _systems;

        [SerializeField] private Config _config = default;

        private void Start()
        {
            Application.targetFrameRate = 60;

            _world = new EcsWorld();
            _systems = new EcsSystems(_world);
            EventRegister.ecsWorld = _world;

            _systems
                .Add(new StackInitSystem())
                .Add(new PlayerInitSystem())
                .Add(new PlayerInputSystem())
                .Add(new MovementSystem())
                .Add(new RotationSystem())
                .Add(new AnimatedSystem())
                .Add(new FollowCameraInitSystem())
                .Add(new FollowCameraSystem())
                .Add(new StackSystem())
                .Add(new TimerSystem<TimerBetweenGenerate>())
                .Add(new GenerateResourceSystem())
                .Add(new CreateResourceViewSystem())
                .Add(new StackResourceTransferSystem())
                .Add(new ResourceTransferSystem())
                .Add(new ResourceTransferBetweenStacksSystem())
                .Add(new VirtualJoystickInitSystem())
                .Add(new VirtualJoystickDirectionSystem())

                .OneFrame<OnJoysticDragEvent>()

                .Inject(GetComponent<ISceneContext>())
                .Inject((IConfig)_config)

                .Init();
        }

        private void Update()
        {
            _systems?.Run();
        }

        private void OnDestroy()
        {
            if (_systems != null)
            {
                _systems.Destroy();
                _systems = null;
                _world.Destroy();
                _world = null;
            }
        }
    }
}
