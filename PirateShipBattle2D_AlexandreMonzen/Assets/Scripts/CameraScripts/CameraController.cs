using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera _camera;
    [SerializeField] private GameObject _target;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    private void Update()
    {
        _camera.transform.position = new Vector3(_target.transform.position.x, _target.transform.position.y, _camera.transform.position.z);
    }
}
