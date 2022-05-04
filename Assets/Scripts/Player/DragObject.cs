﻿using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class DragObject : MonoBehaviour
    {
        [SerializeField] private float _force;
        [SerializeField] private float _smoothTime;
        private Rigidbody _rigidbody;
        private Vector3 _mouseOffset;
        private float _mouseZCoordinate;
        private Camera _mainCamera;

        private void Awake()
        {
            _mainCamera = Camera.main;
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnMouseDown()
        {
            var position = _rigidbody.position;
            _mouseZCoordinate = _mainCamera.WorldToScreenPoint(position).z;
            _mouseOffset = position - GetMouseWorldPose();
        }
        
        private Vector3 GetMouseWorldPose()
        {
            var mousePosition = Input.mousePosition;
            mousePosition.z = _mouseZCoordinate;
            return _mainCamera.ScreenToWorldPoint(mousePosition);
        }

        private void OnMouseDrag()
        {
            _rigidbody.velocity = Vector3.Lerp(_rigidbody.velocity,
                (GetMouseWorldPose() + _mouseOffset - _rigidbody.position) * _force, _smoothTime);
        }
    }
}