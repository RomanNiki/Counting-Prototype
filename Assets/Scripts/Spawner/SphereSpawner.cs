using System.Collections;
using Balls;
using Player.UI;
using Pool.NightPool;
using UnityEngine;

namespace Spawner
{
    public class SphereSpawner : MonoBehaviour
    {
        [SerializeField] private float _spawnDelaySeconds;
        [SerializeField] private float _zBound;
        [SerializeField] private float _xBound;
        [SerializeField] private Ball _ballPrefab;
        [SerializeField] private DropPosition _dropPosition;
        
        public void Init()
        {
            StartCoroutine(SpawnCoroutine());
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
                _dropPosition.SetZPosition(z);
                NightPool.Spawn(_ballPrefab, randomPosition, Quaternion.identity);
            }
        }
    }
}