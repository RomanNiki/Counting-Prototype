using UnityEngine;

namespace Player
{
    public class FollowCamera : MonoBehaviour
    {
        [SerializeField] private float _smoothSpeed;
        [SerializeField] private Vector3 _offset;
        private Transform _playerTransform;

        private void FixedUpdate()
        {
            CameraMove();
        }

        private void CameraMove()
        {
            var transformPosition = transform.position;
            var playerPosition = _playerTransform.position;
            var targetPosition = new Vector3(playerPosition.x, transformPosition.y, playerPosition.z) + _offset;
            var smoothedPosition = Vector3.Lerp(transformPosition, targetPosition, _smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
        }
        
        public void Init(Transform playerTransform)
        {
            _playerTransform = playerTransform;
        }
    }
}