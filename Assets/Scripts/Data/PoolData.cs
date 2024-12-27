using System;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.Serialization;

namespace Data
{
    [Serializable]
    public struct PoolData
    {
        public ItemSettings itemSettings;

        public Transform bonusItemsParent;
        public Transform obstacleItemsParent;

        public int countToPoolBonusItems;
        public int countToPoolObstacleItems;
    }
}