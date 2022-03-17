// ----------------------------------------------------------------------------
// The MIT License
// NightPool is an object pool for Unity https://github.com/MeeXaSiK/NightPool
// Copyright (c) 2021 Night Train Code
// ----------------------------------------------------------------------------

using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Pool.NightPool
{
    [Serializable]
    public sealed class PoolItem
    {
        [FormerlySerializedAs("name")] [SerializeField] private string _name;

        [FormerlySerializedAs("prefab")] [Space] public GameObject _prefab;
                [FormerlySerializedAs("size")] public int _size;
        
        public string Tag => _prefab.name;

        public PoolItem(GameObject go)
        {
            _prefab = go;
        }
    }
}