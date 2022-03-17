// ----------------------------------------------------------------------------
// The MIT License
// NightPool is an object pool for Unity https://github.com/MeeXaSiK/NightPool
// Copyright (c) 2021 Night Train Code
// ----------------------------------------------------------------------------

using UnityEngine;

namespace Pool.NightPool
{
    public class NightPoolEntry : MonoBehaviour
    {
        [SerializeField] private PoolPreset _poolPreset;

        private void Awake()
        {
            NightPool.InstallPoolItems(_poolPreset);
        }

        private void OnDestroy()
        {
            NightPool.Reset();
        }
    }
}