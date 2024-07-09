using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Game.Gameplay.View.ResourceView;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;
    public float moveSpeed => _moveSpeed;

    public float rotationSpeed => _rotationSpeed;
}
