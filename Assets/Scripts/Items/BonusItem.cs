using System.Linq;
using Enums;
using Managers;
using UnityEngine;
using Zenject;

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
            _gameManager.OnGameScoreChange?.Invoke(_scoreToAdd);
            _objectPoolManager.ReturnItem(this, true);
        }
    }
}
