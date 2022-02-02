using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private Transform _playerTransform;
    [SerializeField] private float _smoothSpeed;
    [SerializeField] private Vector3 _offset;

    private void Start()
    {
        _playerTransform = FindObjectOfType<DragObject>().transform;
    }

    private void FixedUpdate()
    {
        var transformPosition = transform.position;
        var position = _playerTransform.position;
        var targetPosition = new Vector3(position.x, transformPosition.y, position.z) + _offset;
        var smoothedPosition = Vector3.Lerp(transformPosition, targetPosition, _smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}