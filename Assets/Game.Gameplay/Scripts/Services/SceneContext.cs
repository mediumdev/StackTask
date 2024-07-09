using UnityEngine;

namespace Game.Gameplay
{
    public class SceneContext : MonoBehaviour, ISceneContext
    {
        [SerializeField] private Transform _resourcesViewRoot = default;
        [SerializeField] private Transform _stackViewRoot = default;

        public Transform resourcesViewRoot => _resourcesViewRoot;
        public Transform stackViewRoot => _stackViewRoot;
    }
}
