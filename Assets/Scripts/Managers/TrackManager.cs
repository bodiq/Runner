using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Character;
using UnityEngine;

namespace Managers
{
    public class TrackManager : MonoBehaviour
    {
        [SerializeField] private Road trackPrefab;
        [SerializeField] private Transform parent;
        [SerializeField] private int trackPoolSize = 5; 

        private readonly Queue<Road> _trackPool = new();
        private float _trackLength;
        private int _plateIndex = 1;

        private bool _isSpawned = false;

        private CharacterMain _player;

        private void OnEnable()
        {
            GameManager.Instance.OnGameStart += PrewarmTracks;
            GameManager.Instance.OnGameEnd +=  ResetTrack;
        }

        private void Start()
        {
            _trackLength = trackPrefab.gameObject.GetComponent<Renderer>().bounds.size.z;
            _player = GameManager.Instance.Character;
        }
        

        private void ResetTrack()
        {
            _isSpawned = false;
            foreach (var road in _trackPool)
            {
                road.ItemSpawner.ResetSpawner();
                Destroy(road.gameObject);
            }
            
            _trackPool.Clear();

            _plateIndex = 1;
        }

        private void Update()
        {
            if (_player.transform.position.z >= _trackLength * _plateIndex && _isSpawned)
            {
                SpawnTrack();
            }
        }

        private void PrewarmTracks()
        {
            for (int i = 0; i < trackPoolSize; i++)
            {
                var track = Instantiate(trackPrefab, new Vector3(0, 0, i * _trackLength), Quaternion.identity, parent);
                track.ItemSpawner.SpawnEnvironmentItems();
                _trackPool.Enqueue(track);
            }
        
            _plateIndex = 1;
            _isSpawned = true;
        }

        private void SpawnTrack()
        {
            var track = _trackPool.Dequeue();

            track.transform.position += new Vector3(0, 0, _trackLength * trackPoolSize);
            track.ItemSpawner.SpawnItems();
        
            _plateIndex++;
            _trackPool.Enqueue(track);
        }

        private void OnDisable()
        {
            GameManager.Instance.OnGameStart -= PrewarmTracks;
            GameManager.Instance.OnGameEnd -=  ResetTrack;
        }
    }
}