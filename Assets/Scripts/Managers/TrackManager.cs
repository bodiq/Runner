using System.Collections.Generic;
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
        private float _trackLength; // Довжина одного сегмента
        private int _plateIndex = 1;
    
        private CharacterMain _player;

        private void Start()
        {
            _trackLength = trackPrefab.gameObject.GetComponent<Renderer>().bounds.size.z; // Довжина сегмента
            _player = GameManager.Instance.Character;
            PrewarmTracks();
        }

        private void Update()
        {
            if (_player.transform.position.z >= _trackLength * _plateIndex)
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
        }

        private void SpawnTrack()
        {
            var track = _trackPool.Dequeue();

            track.transform.position += new Vector3(0, 0, _trackLength * trackPoolSize);
            track.ItemSpawner.SpawnItems();
        
            _plateIndex++;
            _trackPool.Enqueue(track);
        }
    }
}