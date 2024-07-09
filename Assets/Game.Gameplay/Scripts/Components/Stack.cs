using Game.Gameplay.View;
using UnityEngine;
using static Game.Gameplay.View.ResourceView;

namespace Game.Gameplay.Components
{
    public struct Stack
    {
        public ResourceView spawnResourcePrefab;
        public ResourceType takeResourceType;
        public ResourceView rewardResourcePrefab;
        public int neededForReward;
        public float spawnDelay;
        public bool give;
        public bool take;
        public int max;
        public int sizeX;
        public int sizeY;
        public Transform transform;
        public float columnSizeX;
        public float columnSizeY;
        public float columnSizeZ;
    }
}
