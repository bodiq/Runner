using System;
using Enums;
using Items;

namespace Data
{
    [Serializable]
    public struct BonusItemData
    {
        public BonusItemsType itemType;
        public Item itemPrefab;
        public int score;
    }
}