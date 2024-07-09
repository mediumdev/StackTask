using Game.Gameplay.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.Gameplay.Systems
{
    public sealed class PlayerInitSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world = default;

        public void Init()
        {
            var playerObjects = GameObject.FindGameObjectsWithTag("Player");

            foreach (var player in playerObjects)
            {
                var playerEntity = _world.NewEntity();
                var playerView = player.GetComponent<PlayerView>();

                playerEntity.Replace(new Player())
                            .Replace(new Movement { speed = playerView.moveSpeed })
                            .Replace(new Rotation { speed = playerView.rotationSpeed })
                            .Replace(new Direction())
                            .Replace(new Animated { animator = playerView.GetComponent<Animator>() })
                            .Replace(new Follow ())
                            .Replace(new UnityObject<GameObject> { value = player });
            }
        }
    }
}