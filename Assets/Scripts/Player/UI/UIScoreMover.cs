using UnityEngine;

namespace Player.UI
{
    public class UIScoreMover : MonoBehaviour
    {
        [SerializeField] private Vector3 _offSet;
        private Transform _playerTransform;

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            transform.position = _offSet + _playerTransform.position;
        }

        public void Init(Transform player)
        {
            _playerTransform = player.transform;
        }
    }
}
