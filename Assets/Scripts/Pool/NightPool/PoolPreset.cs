// ----------------------------------------------------------------------------
// The MIT License
// NightPool is an object pool for Unity https://github.com/MeeXaSiK/NightPool
// Copyright (c) 2021 Night Train Code
// ----------------------------------------------------------------------------

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Pool.NightPool
{
    [CreateAssetMenu(menuName = "Source/Pool/PoolPreset", fileName = "PoolPreset", order = 0)]
    public class PoolPreset : ScriptableObject
    {
        [SerializeField] private string _poolName;
        
        public List<PoolItem> _poolItems = new List<PoolItem>(256);

        public string GetName()
        {
            return _poolName;
        }
    }
}