using Game.Gameplay.Components;
using Game.UI.Components;
using Leopotam.Ecs;

namespace Game.Gameplay.Systems
{
    public sealed class PlayerInputSystem : IEcsRunSystem
    {
        private readonly EcsFilter<Player, Direction> _playerObjects = default;
        private readonly EcsFilter<VirtualJoystick, Direction> _joystickObjects = default;

        public void Run()
        {
            foreach (var i in _playerObjects)
            {
                ref var playerEntity = ref _playerObjects.GetEntity(i);
                ref var player = ref _playerObjects.Get1(i);
                ref var playerDirection = ref _playerObjects.Get2(i);

                foreach (var j in _joystickObjects)
                {
                    ref var joystickEntity = ref _joystickObjects.GetEntity(j);
                    ref var joystic = ref _joystickObjects.Get1(j);
                    ref var joysticDirection = ref _joystickObjects.Get2(j);

                    playerDirection.value = joysticDirection.value;
                }
            }
        }
    }
}