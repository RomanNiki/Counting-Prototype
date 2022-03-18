using Pool.NightPool;
using UnityEngine;

namespace _Source_Files.Scripts
{
    public class ParticleDestroyer : MonoBehaviour, IPoolItem
    {
        [SerializeField] private ParticleSystem _particleSystem;
        private const float LifeTime = 2f;

        private void Despawn()
        {
            NightPool.Despawn(this);
        }

        public void OnSpawn()
        {
            var particleSystemMain = _particleSystem.main;
            particleSystemMain.startColor = Random.ColorHSV();
            _particleSystem.Play();
            Invoke(nameof(Despawn), LifeTime);
        }

        public void OnDespawn()
        {
        }
    }
}
