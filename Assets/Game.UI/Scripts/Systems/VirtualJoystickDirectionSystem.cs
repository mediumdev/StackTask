using Game.Gameplay.Components;
using Game.UI.Components;
using Leopotam.Ecs;

namespace Game.UI.Systems
{
    public sealed class VirtualJoystickDirectionSystem : IEcsRunSystem
    {
        private readonly EcsFilter<OnJoysticDragEvent> _joysticDragEvents = default;
        private readonly EcsFilter<VirtualJoystick, Direction, UnityObject<VirtualJoystickView>> _joystickObjects = default;

        public void Run()
        {
            foreach (var i in _joysticDragEvents)
            {
                ref var joysticDragEvent = ref _joysticDragEvents.GetEntity(i);
                ref var joysticDrag = ref _joysticDragEvents.Get1(i);

                foreach (var j in _joystickObjects)
                {
                    ref var joystickEntity = ref _joystickObjects.GetEntity(j);
                    ref var joystic = ref _joystickObjects.Get1(j);
                    ref var direction = ref _joystickObjects.Get2(j);
                    ref var joysticView = ref _joystickObjects.Get3(j).value;

                    if (joysticView.transform == joysticDrag.senderGameObject.transform)
                    {
                        direction.value = joysticDrag.direction;
                    }
                }
            }
        }
    }
}