using System.Linq;
using Enums;
using UnityEngine;

namespace Items
{
    public class BonusItem : Item
    {
        [SerializeField] private BonusItemsType typeItem;

        private int _scoreToAdd;
        
        private void Start()
        {
            _scoreToAdd = itemSettings.BonusItemData.FirstOrDefault(item => item.itemType == typeItem).score;
        }

        protected override void OnHit()
        {
            //Add _scoreToAdd to PlayerData + UI
        }
    }
}
