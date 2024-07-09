using System;
using UnityEngine;

namespace Game.Gameplay.View
{
    public class ResourceView : MonoBehaviour
    {
        [SerializeField] private ResourceType _resourceType;

        [Serializable]
        public enum ResourceType
        {
            None, Carrot, Shovel
        }

        public ResourceType resourceType => _resourceType;
    }
}
