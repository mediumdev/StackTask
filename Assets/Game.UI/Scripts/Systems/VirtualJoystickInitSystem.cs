using Game.Gameplay.Components;
using Game.UI.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.UI.Systems
{
    public sealed class VirtualJoystickInitSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world = default;

        public void Init()
        {
            var joystickObjects = GameObject.FindGameObjectsWithTag("VirtualJoystick");

            foreach (var joystick in joystickObjects)
            {
                var joystickEntity = _world.NewEntity();
                var joystickView = joystick.GetComponent<VirtualJoystickView>();

                joystickEntity.Replace(new VirtualJoystick())
                              .Replace(new Direction())
                              .Replace(new UnityObject<VirtualJoystickView> { value = joystickView });
            }
        }
    }
}