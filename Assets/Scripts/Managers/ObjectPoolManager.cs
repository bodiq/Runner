
using System.Collections.Generic;
using System.Linq;
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

        private readonly List<Item> _bonusItemsPool = new();
        private readonly List<Item> _obstacleItemsPool = new();

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
                    _bonusItemsPool.Add(item);
                }
                ShuffleList(_bonusItemsPool);
            }

            foreach (var obstacle in itemSettings.ObstacleItems)
            {
                for (var i = 0; i < countToPoolObstacleItems; i++)
                {
                    var item = Instantiate(obstacle, obstacleItemsParent);
                    item.gameObject.SetActive(false);
                    _obstacleItemsPool.Add(item);
                }
            }
            ShuffleList(_obstacleItemsPool);
        }

        private void ShuffleList(List<Item> list)
        {
            for (var i = list.Count - 1; i > 0; i--)
            {
                int j = Random.Range(0, i + 1);
                var temp = list[i];
                list[i] = list[j];
                list[j] = temp;
            }
        }
        
        public Item GetItem(bool isBonus)
        {
            var targetPool = isBonus ? _bonusItemsPool : _obstacleItemsPool;

            foreach (var item in targetPool)
            {
                if (!item.gameObject.activeSelf)
                {
                    item.gameObject.SetActive(true);
                    return item;
                }
            }
            
            Debug.LogWarning("Pool is empty! Consider increasing the initial size.");
            return null; 
        }

        public void ReturnItem(Item item, bool isBonus)
        {
            if (item == null)
            {
                Debug.LogWarning("Attempted to return a null item.");
                return;
            }

            item.gameObject.SetActive(false);

            var targetPool = isBonus ? _bonusItemsPool : _obstacleItemsPool;
            if (!targetPool.Contains(item))
            {
                targetPool.Add(item);
            }
        }
    }
}
