using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DragObject : MonoBehaviour
{
    [SerializeField] private float _force;
    private Vector3 mouseOffset;
    private float mouseZCoordinate;
    private Rigidbody _rigidbody;
    private Camera _mainCamera;

    private void Start()
    {
        _mainCamera = Camera.main;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        var position = transform.position;
        mouseZCoordinate = _mainCamera.WorldToScreenPoint(position).z;
        mouseOffset = position - GetMouseWorldPose();
    }

    private Vector3 GetMouseWorldPose()
    {
        var mousePosition = Input.mousePosition;
        mousePosition.z = mouseZCoordinate;
        return _mainCamera.ScreenToWorldPoint(mousePosition);
    }

    private void OnMouseDrag()
    {
        _rigidbody.velocity = (GetMouseWorldPose() + mouseOffset - transform.position) * _force;
        Debug.Log(_rigidbody.velocity);
    }
}