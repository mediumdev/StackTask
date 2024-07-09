using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCameraView : MonoBehaviour
{
    [SerializeField] private float _smoothTime;
    [SerializeField] private Vector3 _followOffset;
    public float smoothTime => _smoothTime;

    public Vector3 followOffset => _followOffset;
}
