using System.Collections.Generic;
using Data;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "ScriptableObjects/ItemSettings", fileName = "Items Settings")]
    public class ItemSettings : ScriptableObject
    {
        [SerializeField] private List<BonusItemData> bonusItemsData;


        public List<BonusItemData> BonusItemData => bonusItemsData;
    }
}