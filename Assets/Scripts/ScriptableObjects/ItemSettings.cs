using System.Collections.Generic;
using Data;
using Items;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "ScriptableObjects/ItemSettings", fileName = "Items Settings")]
    public class ItemSettings : ScriptableObject
    {
        [SerializeField] private List<BonusItemData> bonusItemsData;
        [SerializeField] private List<Item> obstacleItems;
        
        public List<BonusItemData> BonusItemData => bonusItemsData;
        public List<Item> ObstacleItems => obstacleItems;
    }
}