using System.Collections.Generic;
using Items;
using Managers;
using ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Track
{
    public class ItemSpawner : MonoBehaviour
    {
        [SerializeField] private Transform[] roadSpawnPoints;
        [SerializeField] private Transform[] environmentSpawnPoints;
        [SerializeField] private ItemSettings itemSettings;
    
        private readonly Dictionary<Item, bool> _spawnedItems = new();

        private int _obstacleSteak = 0;
        private ObjectPoolManager _objectPoolManager;

        [Inject]
        private void Construct(ObjectPoolManager objectPoolManager)
        {
            _objectPoolManager = objectPoolManager;
        }

        public void SpawnItems()
        {
            ResetSpawner();
            SpawnRoadItems();
            SpawnEnvironmentItems();
        }

        public void SpawnEnvironmentItems()
        {
            foreach (var spawnPoint in environmentSpawnPoints)
            {
                SpawnItem(spawnPoint.position, false);
            }
        }

        private void SpawnRoadItems()
        {
            foreach (var spawnPoint in roadSpawnPoints)
            {
                var percent = Random.Range(1f, 100f);

                if (percent <= itemSettings.BonusItemSpawnChance)
                {
                    SpawnItem(spawnPoint.position, true);
                    _obstacleSteak = 0;
                }
                else if (percent <= itemSettings.BonusItemSpawnChance + itemSettings.ObstacleItemSpawnChance && _obstacleSteak < 2)
                {
                    SpawnItem(spawnPoint.position, false);
                    _obstacleSteak++;
                }
                else
                {
                    _obstacleSteak = 0;
                }
            }
        }

        private void SpawnItem(Vector3 spawnPoint, bool isBonus)
        {
            var item = _objectPoolManager.GetItem(isBonus);
            item.transform.position = spawnPoint;
            item.gameObject.SetActive(true);
            _spawnedItems.Add(item, isBonus);
        }

        public void ResetSpawner()
        {
            foreach (var (item, isBonus) in _spawnedItems)
            {
                _objectPoolManager.ReturnItem(item, isBonus);
            }
        
            _obstacleSteak = 0;
            _spawnedItems.Clear();
        }
    }
}
