using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class DragObject : MonoBehaviour
    {
        [SerializeField] private float _force;
        [SerializeField] private float _smoothTime;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private UnityEvent _objectDrag;
        private Transform _objectTransform;
        private Vector3 _mouseOffset;
        private float _mouseZCoordinate;
        private Camera _mainCamera;

        public event UnityAction ObjectDrag
        {
            add => _objectDrag.AddListener(value);
            remove => _objectDrag.RemoveListener(value);
        }
        
        private void Start()
        {
            _objectTransform = transform;
            _mainCamera = Camera.main;
            _rigidbody ??= GetComponent<Rigidbody>();
        }

        private void OnMouseDown()
        {
            var position = transform.position;
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
            _rigidbody.velocity = Vector3.Lerp(_rigidbody.velocity, (GetMouseWorldPose() + _mouseOffset - _objectTransform.position) * _force, _smoothTime) ;
            _objectDrag?.Invoke();
        }
    }
}