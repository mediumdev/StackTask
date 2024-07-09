using Game.Gameplay.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.Gameplay.Systems
{
    public sealed class TimerSystem<TTimerFlag> : IEcsRunSystem
        where TTimerFlag : struct
    {
        private readonly EcsFilter<Timer<TimerBetweenGenerate>> _timerObjects = default;

        public void Run()
        {
            foreach (var i in _timerObjects)
            {
                ref var timer = ref _timerObjects.Get1(i);
                timer.timeLeftSec -= Time.deltaTime;

                if (timer.timeLeftSec <= 0)
                {
                    _timerObjects.GetEntity(i).Del<Timer<TimerBetweenGenerate>>();
                }
            }
        }
    }
}