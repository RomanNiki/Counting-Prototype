using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private int _scorePoint;

    private ICounter _counter;

    private void OnTriggerEnter(Collider other)
    {
        _counter = other.GetComponent<ICounter>();
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