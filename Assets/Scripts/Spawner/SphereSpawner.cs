using System.Collections;
using Balls;
using Player.UI;
using Pool.NightPool;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Spawner
{
    public class SphereSpawner : MonoBehaviour
    {
        [SerializeField] private float _spawnDelaySeconds;
        [SerializeField] private float _zBound;
        [SerializeField] private float _xBound;
        [SerializeField] private Ball _ballPrefab;
        [FormerlySerializedAs("_dropPosition")] [SerializeField] private DropPositionPointer _dropPositionPointer;
        [SerializeField] private UnityEvent<Ball> _createdBall;
        private Coroutine _spawnCoroutine;
        public event UnityAction<Ball> CreatedBall
        {
            add => _createdBall.AddListener(value);
            remove => _createdBall.RemoveListener(value);
        }

        public void Init()
        {
            _spawnCoroutine = StartCoroutine(SpawnCoroutine());
        }

        private IEnumerator SpawnCoroutine()
        {
            var position = transform.position;
            while (true)
            {
                yield return new WaitForSeconds(_spawnDelaySeconds);
                var x = Random.Range(-_xBound, _xBound);
                var z = Random.Range(-_zBound, _zBound);
                var randomPosition = new Vector3(x, position.y, z);
                _dropPositionPointer.SetZPosition(z);
                var ball =  NightPool.Spawn(_ballPrefab, randomPosition, Quaternion.identity);
                _createdBall?.Invoke(ball);
            }
        }

        private void OnDisable()
        {
            StopCoroutine(_spawnCoroutine);
        }
    }
}