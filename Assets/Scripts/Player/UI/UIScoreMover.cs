using UnityEngine;

namespace Player.UI
{
    public class UIScoreMover : MonoBehaviour
    {
        [SerializeField] private DragObject _player;
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

        public void Init(DragObject player)
        {
            _player ??= player;
            _playerTransform = _player.transform;
        }
    }
}
