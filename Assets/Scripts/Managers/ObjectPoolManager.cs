
using System.Collections.Generic;
using Configs;
using Items;
using ScriptableObjects;
using UnityEngine;

namespace Managers
{
    public class ObjectPoolManager : MonoSingleton<ObjectPoolManager>
    {
        [SerializeField] private ItemSettings itemSettings;

        [SerializeField] private Transform bonusItemsParent;
        [SerializeField] private Transform obstacleItemsParent;

        [SerializeField] private int countToPoolBonusItems;
        [SerializeField] private int countToPoolObstacleItems;

        private readonly Queue<Item> _bonusItemsPool = new();
        private readonly Queue<Item> _obstacleItemsPool = new();

        protected override void Awake()
        {
            base.Awake();
            InitializePools();
        }

        private void InitializePools()
        {
            foreach (var bonusItem in itemSettings.BonusItemData)
            {
                for (var i = 0; i < countToPoolBonusItems; i++)
                {
                    var item = Instantiate(bonusItem.itemPrefab, bonusItemsParent);
                    item.gameObject.SetActive(false);
                    _bonusItemsPool.Enqueue(item);
                }
            }

            foreach (var obstacle in itemSettings.ObstacleItems)
            {
                for (var i = 0; i < countToPoolObstacleItems; i++)
                {
                    var item = Instantiate(obstacle, obstacleItemsParent);
                    item.gameObject.SetActive(false);
                    _obstacleItemsPool.Enqueue(item);
                }
            }
        }
        
        public Item GetItem(bool isBonus)
        {
            var targetPool = isBonus ? _bonusItemsPool : _obstacleItemsPool;

            if (targetPool.Count > 0)
            {
                var item = targetPool.Dequeue();
                item.gameObject.SetActive(true);
                return item;
            }

            Debug.LogWarning("Pool is empty! Consider increasing the initial size.");
            return null; 
        }

        public void ReturnItem(Item item, bool isBonus)
        {
            item.gameObject.SetActive(false);
            var targetPool = isBonus ? _bonusItemsPool : _obstacleItemsPool;
            targetPool.Enqueue(item);
        }
    }
}
