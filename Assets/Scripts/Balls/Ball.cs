using Interfaces;
using Pool.NightPool;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Balls
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Renderer))]
    public class Ball : MonoBehaviour, IPoolItem
    {
        [SerializeField] private int _scorePoint;
        private Renderer _meshRenderer;
        private Rigidbody _rigidbody;
        private ICounter _counter;
        
        public int ScorePoints => _scorePoint;

        private void Awake()
        {
            _meshRenderer = GetComponent<Renderer>();
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            ChangeColor(Random.ColorHSV());
        }

        private void OnTriggerEnter(Collider other)
        {
            _counter ??= other.GetComponent<ICounter>();
            _counter?.AddBall(this);
        }

        private void OnTriggerExit(Collider other)
        {
            _counter?.RemoveBall(this);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.TryGetComponent<Bound>(out _))
            {
                NightPool.Despawn(gameObject);
            }
        }

        private void ChangeColor(Color color)
        {
            if (_meshRenderer != null)
            {
                _meshRenderer.material.color = color;
            }
        }

        public void OnSpawn()
        {
            ChangeColor(Random.ColorHSV());
        }

        public void OnDespawn()
        {
            _rigidbody.velocity = Vector3.zero;
        }
    }
}