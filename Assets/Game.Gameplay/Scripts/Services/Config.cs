using UnityEngine;

namespace Game.Gameplay
{
    [CreateAssetMenu(fileName = "Config", menuName = "Game/Config")]
    public sealed class Config : ScriptableObject, IConfig
    {
        [SerializeField] private float _stackTransferDistance = default;
        [SerializeField] private float _resourceTransferSpeed = default;
        [SerializeField] private string _animationRunParamName = default;

        public float stackTransferDistance => _stackTransferDistance;
        public float resourceTransferSpeed => _resourceTransferSpeed;
        public string animationRunParamName => _animationRunParamName;
    }
}
