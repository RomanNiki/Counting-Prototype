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
        [SerializeField] private float _height;
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
            while (true)
            {
                yield return new WaitForSeconds(_spawnDelaySeconds);
            
                var ball =  NightPool.Spawn(_ballPrefab, GetRandomPosition(), Quaternion.identity);
                _createdBall?.Invoke(ball);
            }
        }

        private Vector3 GetRandomPosition()
        {
            var x = Random.Range(-_xBound, _xBound);
            var z = Random.Range(-_zBound, _zBound);
            _dropPositionPointer.SetZPosition(z);
            return new Vector3(x, _height, z);
        }

        private void OnDisable()
        {
            StopCoroutine(_spawnCoroutine);
        }
    }
}