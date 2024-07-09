using UnityEngine;

namespace Game.Gameplay
{
    public interface ISceneContext
    {
        Transform resourcesViewRoot { get; }
        Transform stackViewRoot { get; }
    }
}
