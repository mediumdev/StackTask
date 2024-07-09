using UnityEngine;
using static Game.Gameplay.View.ResourceView;

namespace Game.Gameplay.View
{
    public class StackView : MonoBehaviour
    {
        [SerializeField] private ResourceView _spawnResourcePrefab;
        [SerializeField] private ResourceType _takeResourceType;
        [SerializeField] private float _spawnDelay;
        [SerializeField] private bool _give;
        [SerializeField] private bool _take;
        [SerializeField][Range(0, 100)] private int _max;
        [SerializeField][Range(0, 10)] private int _sizeX;
        [SerializeField][Range(0, 10)] private int _sizeY;
        [SerializeField] private float _columnSizeX;
        [SerializeField] private float _columnSizeY;
        [SerializeField] private float _columnSizeZ;

        public ResourceView spawnResourcePrefab => _spawnResourcePrefab;
        public ResourceType takeResourceType => _takeResourceType;
        public float spawnDelay => _spawnDelay;
        public bool give => _give;
        public bool take => _take;
        public int max => _max;
        public int sizeX => _sizeX;
        public int sizeY => _sizeY;
        public float columnSizeX => _columnSizeX;
        public float columnSizeY => _columnSizeY;
        public float columnSizeZ => _columnSizeZ;
    }
}
