// ----------------------------------------------------------------------------
// The MIT License
// NightPool is an object pool for Unity https://github.com/MeeXaSiK/NightPool
// Copyright (c) 2021 Night Train Code
// ----------------------------------------------------------------------------

using UnityEngine;
using UnityEngine.Serialization;

namespace Pool.NightPool
{
    public class NightPoolDespawner : MonoBehaviour
    {
        [SerializeField] private float _timeToDespawn = 3f;

        private bool _processed;
        private float _timer;

        private void OnEnable()
        {
            Restore();
        }

        private void OnDisable()
        {
            Restore();
        }

        private void Update()
        {
            if (IsDespawnMoment() == false)
                return;
            
            NightPool.Despawn(gameObject);
            OnProcessed();
        }

        private bool IsDespawnMoment()
        {
            if (_processed)
                return false;
            
            _timer += Time.deltaTime;

            if (_timer >= _timeToDespawn)
                return true;

            return false;
        }

        private void Restore()
        {
            _timer = 0f;
            _processed = false;
        }

        private void OnProcessed()
        {
            _processed = true;
            _timer = 0f;
        }
    }
}