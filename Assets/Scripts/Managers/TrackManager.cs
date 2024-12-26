using System.Collections.Generic;
using Character;
using Track;
using UnityEngine;
using Zenject;

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

        private bool _isSpawned;

        private CharacterMain _player;
        private GameManager _gameManager;

        [Inject]
        private void Construct(CharacterMain player, GameManager gameManager)
        {
            _player = player;
            _gameManager = gameManager;
        }

        private void OnEnable()
        {
            _gameManager.OnGameStart += PrewarmTracks;
            _gameManager.OnGameEnd += ResetTrack;
        }

        private void Start()
        {
            _trackLength = trackPrefab.gameObject.GetComponent<Renderer>().bounds.size.z;
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
            if (_player.transform.position.z >= _trackLength * _plateIndex && _isSpawned) SpawnTrack();
        }

        private void PrewarmTracks()
        {
            for (var i = 0; i < trackPoolSize; i++)
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
            _gameManager.OnGameStart -= PrewarmTracks;
            _gameManager.OnGameEnd -= ResetTrack;
        }
    }
}