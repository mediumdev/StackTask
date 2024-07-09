using Game.UI.Components;
using Leopotam.Ecs;
using UnityEngine;

public static class EventRegister
{
    public static EcsWorld ecsWorld;

    public static void RegisterJoysticDragEvent(GameObject senderGameObject, Vector3 direction)
    {
        var eventEntity = ecsWorld.NewEntity();
        ref var eventComponent = ref eventEntity.Get<OnJoysticDragEvent>();
        eventComponent.senderGameObject = senderGameObject;
        eventComponent.direction = direction;
    }
}
