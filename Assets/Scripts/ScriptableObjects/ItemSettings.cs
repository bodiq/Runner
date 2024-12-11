using System;
using System.Collections.Generic;
using Data;
using Items;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "ScriptableObjects/ItemSettings", fileName = "Items Settings")]
    public class ItemSettings : ScriptableObject
    {
        [Header("General Item Information")]
        [SerializeField] private List<BonusItemData> bonusItemsData;
        [SerializeField] private List<Item> obstacleItems;

        [Header("Spawn Item Information")] 
        [Range(0f, 100f)]
        [SerializeField] private float bonusItemSpawnChance;
        [Range(0f, 100f)]
        [SerializeField] private float obstacleItemsSpawnChance;

        public List<BonusItemData> BonusItemData => bonusItemsData;
        public List<Item> ObstacleItems => obstacleItems;

        public float BonusItemSpawnChance => bonusItemSpawnChance;
        public float ObstacleItemSpawnChance => obstacleItemsSpawnChance;
    }
}