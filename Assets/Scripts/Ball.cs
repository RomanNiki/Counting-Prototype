using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
    [SerializeField] private int _scorePoint;
    [SerializeField] private float _extraGravityModifierInBox;
    private Rigidbody _ballRigidbody;
    private ICounter _counter;

    private void Start()
    {
        _ballRigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (_counter == null)
        {
            _ballRigidbody.AddForce(Physics.gravity, ForceMode.Acceleration);
        }
        else
        {
            _ballRigidbody.AddForce(Physics.gravity * _extraGravityModifierInBox, ForceMode.Acceleration);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        _counter ??= other.GetComponent<ICounter>();
        _counter?.UpdateScoreText(_scorePoint);
    }

    private void OnTriggerExit(Collider other)
    {
        _counter?.UpdateScoreText(_scorePoint * -1);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.TryGetComponent<Bound>(out _))
        {
            Destroy(gameObject);
        }
    }
}